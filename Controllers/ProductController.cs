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
            if (product == null)
            {
                return NotFound();
            }
//<<<<<<< HEAD
            //return View("ProductDetails", product);
//=======
            return View(product);
//>>>>>>> 6ac9e244d25a6e26fd79841a2ee910db92ba85d0
        }
       
    }
}
