﻿namespace Izkustvolandia.Domain;

public class Genre
{
    public int GenreId { get; set; }
    
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}