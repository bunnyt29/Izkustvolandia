using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Izkustvolandia.Models.Users;

public class UserDetailsViewModel
{
    public string UserId { get; set; }

    [Required(ErrorMessage = "Полето е зад ължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(100, ErrorMessage = "Въведи не повече от 100 символа.")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Полето е зад ължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(100, ErrorMessage = "Въведи не повече от 100 символа.")]
    public string LastName { get; set; }
    
    public string Name { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    [EmailAddress(ErrorMessage = "Въведи валиден имейл адрес.")]
    public string Email { get; set; }
}