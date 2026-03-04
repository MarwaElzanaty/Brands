using Microsoft.AspNetCore.Mvc;

namespace LocalBrands.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
