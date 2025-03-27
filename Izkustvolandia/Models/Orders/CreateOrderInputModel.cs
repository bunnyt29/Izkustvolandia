using System.ComponentModel.DataAnnotations;
using Izkustvolandia.Models.Products;

namespace Izkustvolandia.Models.Orders;

public class CreateOrderInputModel
{
    [Required(ErrorMessage = "Полето е задължително.")]
    [MinLength(2, ErrorMessage = "Въведи поне 2 символа.")]
    [MaxLength(100, ErrorMessage = "Въведи не повече от 100 символа.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Полето е задължително.")]
    public string PhoneNumber { get; set; }

    public decimal TotalPrice { get; set; }

    public List<DetailsProductViewModel> Products { get; set; } = new List<DetailsProductViewModel>();
}