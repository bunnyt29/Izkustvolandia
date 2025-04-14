using System.Diagnostics;
using Izkustvolandia.Data;
using Microsoft.AspNetCore.Mvc;
using Izkustvolandia.Models;
using Izkustvolandia.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Izkustvolandia.Controllers;

public class HomeController : Controller
{
    private readonly IzkustvolandiaDbContext _context;

    public HomeController(IzkustvolandiaDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _context.Products
            .Include(p => p.Genres)
            .Include(p => p.DrawingTechniques)
            .Take(9)
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
            .ToListAsync();
        return View(products);
    }

    public IActionResult Contact()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}