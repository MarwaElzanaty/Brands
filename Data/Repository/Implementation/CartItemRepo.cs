using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class CartItemRepo : ICartItemRepo
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
            context.CartItem.Add(entity);
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
        // user defined

        public List<CartItem> GetAllIteam(int CartID)
        {
            List<CartItem> cartItems = new List<CartItem>();
            cartItems = context.CartItem.Where(item => item.CartId==CartID).Include(item=> item.Product).ThenInclude(p => p.Brand).ToList();
            return cartItems;

        }
        public CartItem? GetById(int id)
        {
            return context.CartItem.SingleOrDefault(d => d.Id == id);
        }
        public CartItem GetByProductIDCartID(int productID, int cartID)
        {
            return context.CartItem.SingleOrDefault(item => item.CartId==cartID && item.ProductId==productID);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(CartItem entity)
        {
            context.CartItem.Update(entity);
        }
    }
}
