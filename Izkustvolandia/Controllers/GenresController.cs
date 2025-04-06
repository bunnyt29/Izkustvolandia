using Izkustvolandia.Data;
using Izkustvolandia.Domain;
using Izkustvolandia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Izkustvolandia.Controllers;

public class GenresController(IzkustvolandiaDbContext _context) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> All()
    {
        var genres = await _context.Genres
            .Select(g => new GenreViewModel()
            {
                GenreId = g.GenreId,
                Name = g.Name,
            })
            .ToListAsync();
        
        return View(genres);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(GenreViewModel viewModel)
    {
        var alreadyExists = await _context.Genres.AnyAsync(g => g.Name == viewModel.Name);
        if (alreadyExists)
        {
            ModelState.AddModelError("Name", "Вече съществува такъв жанр");
        }

        if (ModelState.IsValid)
        {
            var genre = new Genre
            {
                Name = viewModel.Name,
            };
        
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        
            return RedirectToAction(nameof(All)); 
        }
        else
        {
            return View(viewModel);
        }
        
        
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(int id)
    {
        var genre = await _context.Genres
            .Where(g => g.GenreId == id)
            .Select(g => new GenreViewModel()
            {
                GenreId = g.GenreId,
                Name = g.Name,
            })
            .FirstOrDefaultAsync();
        
        return View(genre);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(GenreViewModel viewModel)
    {
        var alreadyExists = await _context.Genres.AnyAsync(g => g.Name == viewModel.Name);
        if (alreadyExists)
        {
            ModelState.AddModelError("Name", "Вече съществува такъв жанр");
        }

        if (ModelState.IsValid)
        {
            var genre = await _context.Genres
                .FirstOrDefaultAsync(g => g.GenreId == viewModel.GenreId);
        
            genre.Name = viewModel.Name;
        
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        
            return RedirectToAction(nameof(All));
        }
        else
        {
            return View(viewModel);
        }
        
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var genre = await _context.Genres
            .FirstOrDefaultAsync(g => g.GenreId == id);
        
        return View(genre);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(GenreViewModel viewModel)
    {
        var genre = await _context.Genres
            .FirstOrDefaultAsync(g => g.GenreId == viewModel.GenreId);

        if (genre is null)
        {
            return NotFound();
        }
        
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(All));
    }
}