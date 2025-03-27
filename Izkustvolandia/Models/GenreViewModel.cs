using System.ComponentModel.DataAnnotations;

namespace Izkustvolandia.Models;

public class GenreViewModel
{
    public int GenreId { get; set; }
    
    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(50, ErrorMessage = "Въведи не повече от 50 символа.")]
    public string Name { get; set; }
}