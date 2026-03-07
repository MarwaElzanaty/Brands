using LocalBrands.Models;
using LocalBrands.Services.Implementation;
using LocalBrands.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LocalBrands.Controllers
{
   
    public class ReviewController : Controller
    {
        IReviewService ReviewService;
        public ReviewController(IReviewService reviewService)
        {
            ReviewService = reviewService;
        }
        [Authorize]
        [HttpPost]      
        public IActionResult AddReview(int ProductId, int Rating, string Content)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null) return RedirectToAction("Login", "Account");
            // create new Review
            var newReview = new Review
            {
                ProductId = ProductId,
                UserId = userId,
                Rating = Rating,
                Content = Content,
                CreatedAt = DateTime.Now
            };

            ReviewService.AddReview(newReview);

            return RedirectToAction("ProductDetails", "Product", new { id = ProductId });
        }
    }
}
