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

public class OrdersController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IzkustvolandiaDbContext _context;

    public OrdersController(UserManager<User> userManager, IzkustvolandiaDbContext context)
    {
        this._userManager = userManager;
        this._context = context;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Overview()
    {
        var user = await this._userManager.GetUserAsync(User);

        var model = new CreateOrderInputModel();
        
            var products = await this._context.Carts
                .Where(c => c.UserId == user.Id)
                .Select(c => new DetailsProductViewModel()
                {
                    ProductId = c.ProductId,
                    Name = c.Product.Name,
                    Description = c.Product.Description,
                    ImageUrls =c.Product.ImageUrls,
                    Author = c.Product.Author,
                    Width = c.Product.Width,
                    Height = c.Product.Height,
                    Price = c.Product.Price,
                    Genres =c.Product.Genres,
                    DrawingTechniques = c.Product.DrawingTechniques
                })
                .ToListAsync();

            model.Products = products;

            model.TotalPrice += products.Select(p => p.Price).Sum();

        return View(model);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateOrderInputModel input)
    {
        var user = await this._userManager.GetUserAsync(User);

        var order = new Order()
        {
            TotalSum = input.TotalPrice,
            Address = input.Address,
            PhoneNumber = input.PhoneNumber,
            UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value
        };

        await this._context.Orders.AddAsync(order);
        await this._context.SaveChangesAsync();

        var orderedProducts = await this._context.Carts.
            Where(c => c.UserId == user.Id).ToListAsync();

        foreach (var product in orderedProducts)
        {
            var item = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);
            
            var orderProduct = new OrderProduct()
            {
                OrderId = order.OrderId,
                ProductId = product.ProductId
            };
            
            await this._context.OrderProducts.AddAsync(orderProduct);

            item.IsDeleted = true;
            
            await this._context.SaveChangesAsync();
        }
        
        user.Products.Clear();
        
        await this._context.SaveChangesAsync();

        return RedirectToAction("Confirmation");
    }

    [HttpGet]
    [Authorize]
    public IActionResult Confirmation()
    {
        return this.View();
    }
    
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var orders = await this._context.Orders
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
                        Name = u.FirstName  + " " + u.LastName,
                        Email = u.Email
                    })
                    .SingleOrDefault(),
                Products = new List<DetailsProductViewModel>(),
                CreatedOn = o.CreatedOn,
                DeliveryOn = o.DeliveryOn
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
    
    [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var user = await this._userManager.GetUserAsync(User);

            var orders = await this._context.Orders
                .Where(o => o.UserId == user.Id)
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
                    Products = new List<DetailsProductViewModel>(),
                    CreatedOn = o.CreatedOn,
                    DeliveryOn = o.DeliveryOn
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