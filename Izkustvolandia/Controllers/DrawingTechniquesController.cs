using Izkustvolandia.Data;
using Izkustvolandia.Domain;
using Izkustvolandia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Izkustvolandia.Controllers;

public class DrawingTechniquesController(IzkustvolandiaDbContext _context) : Controller
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> All()
    {
        var drawingTechniques = await _context.DrawingTechniques
            .Select(dt => new DrawingTechniqueViewModel()
            {
                DrawingTechniqueId = dt.DrawingTechniqueId,
                Name = dt.Name,
            })
            .ToListAsync();
        
        return View(drawingTechniques);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(DrawingTechniqueViewModel viewModel)
    {
        var alreadyExists = await _context.DrawingTechniques.AnyAsync(dw => dw.Name == viewModel.Name);
        if (alreadyExists)
        {
            ModelState.AddModelError("Name", "Такава техника вече съществува");
        }

        if (ModelState.IsValid)
        {
           
            var drawingTechnique = new DrawingTechnique()
            {
                Name = viewModel.Name,
            };
        
            _context.DrawingTechniques.Add(drawingTechnique);
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
        var drawingTechnique = await _context.DrawingTechniques
            .Where(dt => dt.DrawingTechniqueId == id)
            .Select(dt => new DrawingTechniqueViewModel()
            {
                DrawingTechniqueId = dt.DrawingTechniqueId,
                Name = dt.Name,
            })
            .FirstOrDefaultAsync();
        
        return View(drawingTechnique);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(DrawingTechniqueViewModel viewModel)
    {
        var alreadyExists = await _context.DrawingTechniques.AnyAsync(dw => dw.Name == viewModel.Name);
        if (alreadyExists)
        {
            ModelState.AddModelError("Name", "Такава техника вече съществува");
        }

        if (ModelState.IsValid)
        {
            var drawingTechnique = await _context.DrawingTechniques
                .FirstOrDefaultAsync(dt => dt.DrawingTechniqueId == viewModel.DrawingTechniqueId);
        
            drawingTechnique.Name = viewModel.Name;
        
            _context.DrawingTechniques.Update(drawingTechnique);
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
        var drawingTechnique = await _context.DrawingTechniques
            .FirstOrDefaultAsync(dt => dt.DrawingTechniqueId == id);
        
        return View(drawingTechnique);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(DrawingTechniqueViewModel viewModel)
    {
        var drawingTechnique = await _context.DrawingTechniques
            .FirstOrDefaultAsync(dt => dt.DrawingTechniqueId == viewModel.DrawingTechniqueId);

        if (drawingTechnique is null)
        {
            return NotFound();
        }
        
        _context.DrawingTechniques.Remove(drawingTechnique);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(All));
    }
}