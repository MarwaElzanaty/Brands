using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class CartRepo : ICartRepo
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
            
            context.Cart.Add(entity);
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
            return context.Cart.SingleOrDefault(c => c.UserId == id.ToString());
        }
        //extend
        public Cart? GetByIdString(string id)
        {
            return context.Cart.SingleOrDefault(c => c.UserId == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Cart entity)
        {
            context.Update(entity);
        }
    }
}
