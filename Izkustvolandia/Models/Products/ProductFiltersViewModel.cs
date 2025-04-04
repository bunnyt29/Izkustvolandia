using Izkustvolandia.Domain;

namespace Izkustvolandia.Models.Products;

public class ProductFiltersViewModel
{
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    
    public string Genre { get; set; }
    
    public ICollection<DrawingTechnique> DrawingTechniques { get; set; } = new List<DrawingTechnique>();
    
    public string DrawingTechnique { get; set; }
    
    public int MinPrice { get; set; }

    public int MaxPrice { get; set; } = 5000;
}