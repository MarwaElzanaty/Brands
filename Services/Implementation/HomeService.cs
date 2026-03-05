using LocalBrands.Data.Repository.Implementation;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using LocalBrands.Services.Interfaces;
namespace LocalBrands.Services.Implementation
{
    public class HomeService :IHomeService
    {
        // dependency injection
        IRepository<Product> productRepo;
        public HomeService(IRepository<Product> productRepo)
        {
            this.productRepo = productRepo;
        }
        public List<Product> AllProducts()
        {
            List<Product> allproducts = productRepo.GetAll();
            return allproducts;
        }

        public Product ProductByID(int id)
        {
            Product allproducts = productRepo.GetById(id);
            return allproducts;
        }

        public List<Product> NewArrivals(int item)
        {
            List<Product> newArrivals = productRepo.GetAll()
                .OrderByDescending(p => p.createdAt).Take(item).ToList();
            return newArrivals;
        }

        public List<Product> BestSellers(int item)
        {
            List<Product> bestSellers = productRepo.GetAll()
           .OrderByDescending(p => p.SalesCount).Take(item).ToList();
            return bestSellers;
        }           
    }
}

