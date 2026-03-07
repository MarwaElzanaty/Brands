using LocalBrands.Models;

namespace LocalBrands.Data.Repository.Interfaces
{
    public interface IReviewRepo : IRepository<Review>
    {
        public List<Review> GetAllByProdId(int Product_id);
    }
}
