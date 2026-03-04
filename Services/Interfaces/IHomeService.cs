using LocalBrands.Models;

namespace LocalBrands.Services.Interfaces
{
    public interface IHomeService
    {
        public List<Product> AllProducts();
        public Product ProductByID(int id);
        public List<Product> NewArrivals(int item);
        public List<Product> BestSellers(int item);

    }
}
