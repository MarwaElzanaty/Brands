using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Interfaces
{
    public interface ICartRepo: IRepository<Cart>
    {
        //public Cart? GetByUserId(string userId);
    }
}
