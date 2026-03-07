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
<<<<<<< HEAD
=======

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
        public CartRepo(ApplicationDB context)
        {
            this.context = context;
        }

<<<<<<< HEAD
        public void Add(Cart entity)
        {
            var existingCart = context.Cart.FirstOrDefault(c
            => c.UserId == entity.UserId);
=======
        // Add Cart (مع منع التكرار)
        public void Add(Cart entity)
        {
            var existingCart = context.Cart.FirstOrDefault(c => c.UserId == entity.UserId);
>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
            if (existingCart == null)
            {
                context.Cart.Add(entity);
            }
<<<<<<< HEAD
=======
            // لو فيه كارت موجود بالفعل لنفس الـ UserId، مش بنضيف جديد
>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
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
<<<<<<< HEAD
            .Include(u => u.User)
            .Include(u => u.CartItems)
            .ToList();
=======
                .Include(u => u.User)
                .Include(u => u.CartItems)
                .ToList();
>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
        }
        public Cart? GetById(int id)
        {
<<<<<<< HEAD
            return context.Cart.FirstOrDefault(c => c.UserId == id.ToString());
        }
        public Cart? GetByIdString(string id)
        {
            return context.Cart.FirstOrDefault(c => c.UserId == id);
        }   
=======
            // استخدم FirstOrDefault بدل SingleOrDefault
            return context.Cart.FirstOrDefault(c => c.UserId == id.ToString());
        }

        public Cart? GetByIdString(string id)
        {
            // استخدم FirstOrDefault بدل SingleOrDefault
            return context.Cart.FirstOrDefault(c => c.UserId == id);
        }

>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
        public void Save()
        {
            context.SaveChanges();
        }
        public void Update(Cart entity)
        {
            context.Update(entity);
        }
<<<<<<< HEAD
        public Cart? GetByUserId(string userId)
        {
            return context.Cart
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefault(c => c.UserId == userId);
        }

=======

        public Cart? GetByUserId(string userId)
        {
            // استخدم FirstOrDefault بدل SingleOrDefault
            return context.Cart
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.UserId == userId);
        }
>>>>>>> 3e6609e20bbaee3eea91a9662c1e90e2fed8f240
    }
}