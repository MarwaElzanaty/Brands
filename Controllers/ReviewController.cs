using Microsoft.AspNetCore.Mvc;

namespace LocalBrands.Controllers
{
    public class ReviewController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
