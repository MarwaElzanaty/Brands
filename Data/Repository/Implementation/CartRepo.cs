using LocalBrands.Controllers;
using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;
namespace LocalBrands.Data.Repository.Implementation
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDB context;
        public CartRepo(ApplicationDB context)
        {
            this.context = context;
        }

        public void Add(Cart entity)
        {
            var existingCart = context.Cart.FirstOrDefault(c
            => c.UserId == entity.UserId);
            if (existingCart == null)
            {
                context.Cart.Add(entity);
            }
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
            return context.Cart
            .Include(u => u.User)
            .Include(u => u.CartItems)
            .ToList();
        }
        public Cart? GetById(int id)
        {
            return context.Cart.FirstOrDefault(c => c.UserId == id.ToString());
        }
        public Cart? GetByIdString(string id)
        {
            return context.Cart.FirstOrDefault(c => c.UserId == id);
        }   
        public void Save()
        {
            context.SaveChanges();
        }
        public void Update(Cart entity)
        {
            context.Update(entity);
        }
        public Cart? GetByUserId(string userId)
        {
            return context.Cart
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefault(c => c.UserId == userId);
        }

    }
}