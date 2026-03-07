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
<<<<<<< HEAD
=======

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
        public CartItemRepo(ApplicationDB context)
        {
            this.context = context;
        }
<<<<<<< HEAD
        // CRUD operations
        public void Add(CartItem entity)
        {
            var existingItem = context.CartItem
                            .FirstOrDefault(ci => ci.CartId == entity.CartId && ci.ProductId == entity.ProductId);
=======

        // CRUD operations
        public void Add(CartItem entity)
        {
            // قبل ما نضيف، نتأكد إن المنتج مش موجود بالفعل في نفس الكارت
            var existingItem = context.CartItem
                .FirstOrDefault(ci => ci.CartId == entity.CartId && ci.ProductId == entity.ProductId);

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
            if (existingItem == null)
            {
                context.CartItem.Add(entity);
            }
            else
            {
<<<<<<< HEAD
=======
                // لو موجود بالفعل، نعمل Update للكمية بدل ما نضيف صف جديد
>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
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
<<<<<<< HEAD
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
=======
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
>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
        }

        public CartItem? GetById(int id)
        {
<<<<<<< HEAD
            return context.CartItem.FirstOrDefault(d => d.Id== id);
        }
        public CartItem? GetByProductIDCartID(int productId,int cartId)
        {
             return context.CartItem
                .FirstOrDefault(item => item.CartId == cartId && item.ProductId == productId);
=======
            return context.CartItem.FirstOrDefault(d => d.Id == id);
        }

        public CartItem? GetByProductIDCartID(int productId, int cartId)
        {
            // استبدلنا SingleOrDefault بـ FirstOrDefault
            return context.CartItem.FirstOrDefault(item => item.CartId == cartId && item.ProductId == productId);
>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
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

        public List<CartItem> GetByCartId(int cartId)
        {
            return context.CartItem
                .Include(ci => ci.Product)
                .Where(ci => ci.CartId == cartId)
                .ToList();
        }
    }
}