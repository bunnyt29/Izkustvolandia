namespace Izkustvolandia.Domain;

public class ProductDrawingTechnique
{
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int DrawingTechniqueId { get; set; }
    public DrawingTechnique DrawingTechnique { get; set; }
}