using Izkustvolandia.Models.Products;
using Izkustvolandia.Models.Users;

namespace Izkustvolandia.Models.Orders;

public class OrderDetailsOutputModel
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public UserDetailsViewModel User { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public decimal TotalSum { get; set; }

    public List<DetailsProductViewModel> Products { get; set; }
}