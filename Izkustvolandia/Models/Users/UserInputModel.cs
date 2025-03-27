using System.ComponentModel.DataAnnotations;

namespace Izkustvolandia.Models.Users;

public class UserInputModel
{
    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(100, ErrorMessage = "Въведи не повече от 100 символа.")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(100, ErrorMessage = "Въведи не повече от 100 символа.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [EmailAddress(ErrorMessage = "Въведи валиден имейл адрес.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [StringLength(100, ErrorMessage = "Паролата трябва да бъде между 6 и 100 символа.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}