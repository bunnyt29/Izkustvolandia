using Izkustvolandia.Domain;

namespace Izkustvolandia.Models.Products;

public class ListingProductViewModel
{
    public ICollection<ProductViewModel> Products { get; set; }
    
    public ProductFiltersViewModel Filters { get; set; }
}