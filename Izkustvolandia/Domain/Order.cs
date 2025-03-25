namespace Izkustvolandia.Domain;

public class Order
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public decimal TotalSum { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; } = new HashSet<OrderProduct>();
}