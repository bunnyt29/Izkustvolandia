﻿namespace Izkustvolandia.Models.Products;

public class CreateProductInputModel
{
    public IFormFile Image { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Author { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public decimal Price { get; set; }
}