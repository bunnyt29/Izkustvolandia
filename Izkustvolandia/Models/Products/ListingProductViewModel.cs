using Izkustvolandia.Domain;

namespace Izkustvolandia.Models.Products;

public class ListingProductViewModel
{
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    
    public ICollection<DrawingTechnique> DrawingTechniques { get; set; } = new List<DrawingTechnique>();
    
    public ICollection<ProductViewModel> Products { get; set; }
    
    public int MinPrice { get; set; }

    public int MaxPrice { get; set; } = 5000;
}