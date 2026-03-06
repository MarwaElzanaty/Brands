using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class CartRepo : ICartRepo //, IRepository<Cart>
    {
        // Ref from context
        ApplicationDB context;

        // context injected 
        public CartRepo(ApplicationDB context)
        {
            this.context = context;
        }
        //crud operation
        public void Add(Cart entity)
        {
            context.Add(entity);
        }
        public void Delete(Cart entity)
        {
            context.Remove(entity);
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                context.Remove(item);
            }
        }

        public List<Cart> GetAll()
        {
            List<Cart> list = new List<Cart>();
            list= context.Cart.Include(u=>u.User).Include(u=>u.CartItems).ToList();
            return list;
        }

        public Cart? GetById(int id)
        {
            return context.Cart.SingleOrDefault(c => c.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Cart entity)
        {
            context.Update(entity);
        }
        //public Cart? GetByUserId(string userId)
        //{
        //    return context.Cart
        //        .Include(c => c.CartItems)
        //        .ThenInclude(ci => ci.Product)
        //        .SingleOrDefault(c => c.UserId == userId);
        //}
    }
}
