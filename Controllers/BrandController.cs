using Microsoft.AspNetCore.Mvc;

namespace LocalBrands.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
