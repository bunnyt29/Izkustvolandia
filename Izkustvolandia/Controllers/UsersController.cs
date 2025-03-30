using System.Security.Claims;
using Izkustvolandia.Data;
using Izkustvolandia.Domain;
using Izkustvolandia.Models.Orders;
using Izkustvolandia.Models.Products;
using Izkustvolandia.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Izkustvolandia.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<User> _userManager;
	private readonly IzkustvolandiaDbContext _context;

	public UsersController(UserManager<User> userManager, IzkustvolandiaDbContext context)
	{
		this._userManager = userManager;
		this._context = context;
	}

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Details()
    {
	    var user = await this._userManager.GetUserAsync(User);

	    var model = new UserDetailsViewModel()
	    {
		    Email = user.Email,
		    UserId = user.Id,
		    Name = user.FirstName + " " + user.LastName,
	    };

	    return this.View(model);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult All()
    {
        var users = this._context.Users
            .Select(u => new UserDetailsViewModel()
            {
                UserId = u.Id,
                Name = u.FirstName + " " + u.LastName,
                Email = u.Email
            })
            .ToList();

        return View(users);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Edit(string id)
    {
        if (!this.User.IsInRole("Admin") || id == null)
        {
            id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        var user = this._context.Users
            .Where(u => u.Id == id)
            .Select(u => new UserDetailsViewModel()
            {
                UserId = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            })
            .Single();

        return View(user);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Update(string id, UserInputModel input)
    {
        if (!this.User.IsInRole("Admin"))
        {
            id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        var user = this._context.Users
            .FirstOrDefault(u => u.Id == id);

        user.FirstName = input.FirstName;
        user.LastName = input.LastName;
        user.Email = input.Email;
        user.NormalizedEmail = input.Email.ToUpper();
        user.UserName = input.Email;
        user.UserName = input.Email.ToUpper();

        this._context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(string id)
    {

        foreach (var order in this._context.Orders.Where(o => o.UserId == id))
        {
            foreach (var orderProduct in this._context.OrderProducts.Where(op => op.OrderId == order.OrderId))
            {
                this._context.OrderProducts.Remove(orderProduct);
            }

            this._context.Orders.Remove(order);
        }

        var user = this._context.Users
            .FirstOrDefault(u => u.Id == id);

        this._context.Users.Remove(user);
        this._context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Add()
        => View();

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(UserInputModel input)
    {
        var user = new User
        {
            UserName = input.Email,
            Email = input.Email,
            FirstName = input.FirstName,
            LastName = input.LastName,
        };

        await _userManager.CreateAsync(user, input.Password);

        return RedirectToAction("All");
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Orders()
    {
	    var orders = await this._context.Orders
		    .Where(o => o.UserId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
		    .Select(o => new OrderDetailsOutputModel()
		    {
			    Id = o.OrderId,
			    TotalSum = o.TotalSum,
			    Address = o.Address,
			    PhoneNumber = o.PhoneNumber,
			    UserId = o.UserId,
			    User = this._context.Users
				    .Where(u => u.Id == o.UserId)
				    .Select(u => new UserDetailsViewModel()
				    {
					    UserId = u.Id,
					    Name = u.FirstName + " " + u.LastName,
					    Email = u.Email
				    })
				    .SingleOrDefault(),
			    Products = new List<DetailsProductViewModel>()
		    })
		    .ToListAsync();

	    foreach (var order in orders)
	    {
		    var orderProducts = await this._context.OrderProducts
			    .Where(op => op.OrderId == order.Id)
			    .ToListAsync();

		    foreach (var orderProduct in orderProducts)
		    {
			    var product = await this._context.Products
				    .Where(p => p.ProductId == orderProduct.ProductId)
				    .Select(p => new DetailsProductViewModel()
				    {
					    ProductId = p.ProductId,
					    Name = p.Name,
					    Description = p.Description,
					    ImageUrls = p.ImageUrls,
					    Author = p.Author,
					    Width = p.Width,
					    Height = p.Height,
					    Price = p.Price,
					    Genres = p.Genres,
					    DrawingTechniques = p.DrawingTechniques
				    })
				    .FirstOrDefaultAsync();

			    order.Products.Add(product);
		    }
	    }

	    return this.View(orders);
    }
}