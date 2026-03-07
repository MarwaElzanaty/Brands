using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;
namespace LocalBrands.Data.Repository.Interfaces
{
    public interface ICartItemRepo : IRepository<CartItem>
    {
        public CartItem GetByProductIDCartID(int productID, int cartID);
        public List<CartItem> GetAllIteam(int CartID);
        public List<CartItem> GetByCartId(int cartId);
<<<<<<< HEAD
=======

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
    }
}