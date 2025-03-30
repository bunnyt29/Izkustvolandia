using Izkustvolandia.Domain;

namespace Izkustvolandia.Models.Products;

public class ProductViewModel
{
    public int ProductId { get; set; }
    
    public IFormFile? Image { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Author { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public decimal Price { get; set; }
    
    public bool ProductInCart { get; set; } = false;

    public bool IsDeleted { get; set; } = false;
    
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();
    
    public ICollection<DrawingTechnique> DrawingTechniques { get; set; } = new HashSet<DrawingTechnique>();
}