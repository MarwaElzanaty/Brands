using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
namespace LocalBrands.Data.Repository.Implementation
{
    public class CartItemRepo : ICartItemRepo
    {
        private readonly ApplicationDB context;

        public CartItemRepo(ApplicationDB context)
        {
            this.context = context;
        }
        // CRUD operations       
        public void Add(CartItem entity)
        {
            // قبل ما نضيف، نتأكد إن المنتج مش موجود بالفعل في نفس الكارت
            var existingItem = context.CartItem
                .FirstOrDefault(ci => ci.CartId == entity.CartId && ci.ProductId == entity.ProductId);

            if (existingItem == null)
            {
                context.CartItem.Add(entity);
            }
            else
            {
                existingItem.Quantity = entity.Quantity;
                existingItem.AddedAt = DateTime.Now;
                context.CartItem.Update(existingItem);
            }
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
            return context.CartItem
            .Include(c => c.Cart)
            .Include(c => c.Product)
            .ToList();
        }
        public List<CartItem> GetAllIteam(int cartId)
        {
            return context.CartItem
            .Where(item => item.CartId == cartId)
            .Include(item => item.Product)
            .ThenInclude(p => p.Brand)
            .ToList();               
        }

        public CartItem? GetById(int id)
        {
            return context.CartItem.FirstOrDefault(d => d.Id== id);
        }
        public CartItem? GetByProductIDCartID(int productId,int cartId)
        {
             return context.CartItem
                .FirstOrDefault(item => item.CartId == cartId && item.ProductId == productId);
        }


        public void Save()
        {
            context.SaveChanges();
        }   
        public List<CartItem> GetByCartId(int cartId)
        {
            return context.CartItem
            .Include(ci => ci.Product)
            .Where(ci => ci.CartId == cartId).ToList();
        }

        public void Update(CartItem entity)
        {
            context.CartItem.Update(entity);
        }
    }
}