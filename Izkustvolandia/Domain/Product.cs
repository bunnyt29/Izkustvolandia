namespace Izkustvolandia.Domain;

public class Product
{
    public int ProductId { get; set; }

    public List<string> ImageUrls { get; set; } = new();
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Author { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public decimal Price { get; set; }
    
    public DateTime CreatedOn { get; set; } = DateTime.Now; 
    
    public bool IsDeleted { get; set; } = false;
    
    public ICollection<DrawingTechnique> DrawingTechniques { get; set; }  = new HashSet<DrawingTechnique>();
    
    public ICollection<Genre> Genres { get; set; }  = new HashSet<Genre>();
    
    public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();

    public ICollection<User> Users { get; set; } = new HashSet<User>();
}