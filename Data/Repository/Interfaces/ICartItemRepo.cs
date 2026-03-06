using LocalBrands.Models;

namespace LocalBrands.Data.Repository.Interfaces
{
    public interface ICartItemRepo:IRepository<CartItem>
    {
        public CartItem GetByProductIDCartID(int productID, int cartID);
        public List<CartItem> GetAllIteam(int CartID);
    }
}
