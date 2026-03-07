using LocalBrands.Data.Repository.Implementation;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using LocalBrands.Services.Interfaces;

namespace LocalBrands.Services.Implementation
{
    public class ReviewService : IReviewService
    {
        IReviewRepo reviewRepo;
        public ReviewService(IReviewRepo reviewRepo)
        {
            this.reviewRepo = reviewRepo;
        }
        /// logic of Reviews::
        public List<Review> GetReviewsOfOneProduct(int ProductId)
        {
            List<Review> reviews;
            reviews= reviewRepo.GetAllByProdId(ProductId);
            return reviews;
        }

        // to save Review to Repo
        public void AddReview(Review review)
        {
            reviewRepo.Add(review);
            reviewRepo.Save();
        }
    }
}
