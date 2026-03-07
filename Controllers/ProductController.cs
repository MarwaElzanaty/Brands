using LocalBrands.Models;
using LocalBrands.Services.Interfaces;
using LocalBrands.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LocalBrands.Controllers
{
    public class ProductController : Controller
    {
        IHomeService HomeService;
        IReviewService ReviewService;
        IOrderService OrderService;
        public ProductController(IHomeService homeService, IReviewService reviewService, IOrderService orderService)
        {
            HomeService = homeService;
            ReviewService = reviewService;
            OrderService = orderService;
        }       
       // /Product/ProductDetails/4
        public IActionResult ProductDetails(int id)
        {
            ProductDetailsViewModel ProdViewModel = new ProductDetailsViewModel();
            ProdViewModel.Product= HomeService.ProductByID(id);
            // Logic Of Reviews:
            ProdViewModel.Reviews= ReviewService.GetReviewsOfOneProduct(id);

            // Logic of : if User made an order ,then he can make Review:
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                ProdViewModel.CanLeaveReview = OrderService.HasUserPurchasedProduct(userId, id);
            }
            return View(ProdViewModel); 
            
        }

    }
}
