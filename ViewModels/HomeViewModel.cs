using LocalBrands.Models;

namespace LocalBrands.ViewModels
{
    public class HomeViewModel
    {
       public List<Product> NewArrivals { get; set; }
       public List<Product> BestSellers { get; set; }
    }
}
