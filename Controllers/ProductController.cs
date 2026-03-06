using LocalBrands.Models;
using LocalBrands.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocalBrands.Controllers
{
    public class ProductController : Controller
    {
        IHomeService HomeService;
        public ProductController(IHomeService homeService)
        {
            HomeService = homeService;
        }       
       // /Product/ProductDetails/4
        public IActionResult ProductDetails(int id)
        {
            var product= HomeService.ProductByID(id);
           
            return View(product);
        }
       
    }
}
