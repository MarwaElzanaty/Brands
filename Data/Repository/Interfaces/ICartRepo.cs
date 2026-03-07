using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;
namespace LocalBrands.Data.Repository.Interfaces
{
    public interface ICartRepo : IRepository<Cart>
    {
        public Cart? GetByIdString(string id);
        public Cart? GetByUserId(string userId);
<<<<<<< HEAD
=======

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
    }
}