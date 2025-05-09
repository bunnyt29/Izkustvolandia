﻿namespace Izkustvolandia.Models.Products;

public class EditProductInputModel
{
    public int ProductId { get; set; }
    
    public IFormFile[]? Images { get; set; }

    public List<string> ImageUrls { get; set; } = new();
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Author { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public decimal Price { get; set; }
    
    public List<int> GenreIds { get; set; } = new();
    
    public List<int> DrawingTechniqueIds { get; set; } = new();
}