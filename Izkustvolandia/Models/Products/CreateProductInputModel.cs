using System.ComponentModel.DataAnnotations;

namespace Izkustvolandia.Models.Products;

public class CreateProductInputModel
{
    [Required(ErrorMessage = "Полето е задължително.")]
    public IFormFile Image { get; set; }
    
    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(50, ErrorMessage = "Въведи не повече от 50 символа.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(20, ErrorMessage = "Въведи поне 20 символа.")]
    [MaxLength(500, ErrorMessage = "Въведи не повече от 500 символа.")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(50, ErrorMessage = "Въведи не повече от 50 символа.")]
    public string Author { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [Range(0.01, Double.MaxValue, ErrorMessage = "Широчината трябва да е положително число!")]
    public double Width { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [Range(0.01, Double.MaxValue, ErrorMessage = "Височината трябва да е положително число!")]
    public double Height { get; set; }
    
    [Required(ErrorMessage = "Полето е задължително.")]
    [Range(0.01, Double.MaxValue, ErrorMessage = "Неправилно въведена цена.")]

    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Полето е задължително. Изберете жанр!")]
    [MinLength(1, ErrorMessage = "Избери поне една опция!")]
    public List<int> GenreIds { get; set; } = new();
    
    [Required(ErrorMessage = "Полето е задължително. Изберете техника на рисуване!")]
    [MinLength(1, ErrorMessage = "Избери поне една опция!")]
    public List<int> DrawingTechniqueIds { get; set; } = new();
}