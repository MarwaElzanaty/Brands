using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class CartItemRepo : ICartItemRepo //,IRepository<CartItem>
    {
        // Ref from context
        ApplicationDB context;

        // context injected 
        public CartItemRepo(ApplicationDB context)
        {
            this.context = context;
        }

        // crud operations
        public void Add(CartItem entity)
        {
            context.Add(entity);
        }
        public void Delete(CartItem entity)
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
        public List<CartItem> GetAll()
        {
           List<CartItem> cartItems = new List<CartItem>();
            cartItems= context.CartItem.Include(c=>c.Cart).Include(c=>c.Product).ToList();
            return cartItems;
        }

        public CartItem? GetById(int id)
        {
            return context.CartItem.SingleOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(CartItem entity)
        {
            context.Update(entity);
        }
        //public List<CartItem> GetByCartId(int cartId)
        //{
        //    return context.CartItem
        //        .Include(ci => ci.Product)
        //        .Where(ci => ci.CartId == cartId)
        //        .ToList();
        //}
    }
}
