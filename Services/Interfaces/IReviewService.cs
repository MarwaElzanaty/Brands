using LocalBrands.Models;

namespace LocalBrands.Services.Interfaces
{
    public interface IReviewService
    {
        public List<Review> GetReviewsOfOneProduct(int ProductId);
        void AddReview(Review review);
    }
}
