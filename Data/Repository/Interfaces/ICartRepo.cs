using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;
namespace LocalBrands.Data.Repository.Interfaces
{
    public interface ICartRepo : IRepository<Cart>
    {
        public Cart? GetByIdString(string id);
        public Cart? GetByUserId(string userId);
    }
}