namespace Izkustvolandia.Domain;

public class DrawingTechnique
{
    public int DrawingTechniqueId { get; set; }
    
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}