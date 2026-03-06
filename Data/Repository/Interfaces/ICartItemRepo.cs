using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Interfaces
{
    public interface ICartItemRepo: IRepository<CartItem>
    {
        //public List<CartItem> GetByCartId(int cartId);
    }
}
