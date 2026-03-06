using LocalBrands.Models;

namespace LocalBrands.Data.Repository.Interfaces
{
    public interface ICartRepo :IRepository<Cart>
    {
        public Cart? GetByIdString(string id);
       
    }
}
