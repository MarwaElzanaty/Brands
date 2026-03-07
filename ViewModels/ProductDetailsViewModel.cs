using LocalBrands.Models;

namespace LocalBrands.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set;}
        public List<Review> Reviews { get; set; }
        public bool CanLeaveReview { get; set; }
    }
}
