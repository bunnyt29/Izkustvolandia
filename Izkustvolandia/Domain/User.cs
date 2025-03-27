using Microsoft.AspNetCore.Identity;

namespace Izkustvolandia.Domain;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    
    public ICollection<Product> Products { get; set; } = new List<Product>();
}