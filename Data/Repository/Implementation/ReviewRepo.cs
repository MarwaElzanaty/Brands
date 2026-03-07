using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class ReviewRepo : IReviewRepo
    {
        // Ref from context
        ApplicationDB context;

        // context injected 
        public ReviewRepo(ApplicationDB context)
        {
            this.context = context;
        }
        // crud operations
        public void Add(Review entity)
        {
           context.Add(entity);
        }

        public void Delete(Review entity)
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

        public List<Review> GetAll()
        {
            List<Review> reviews= new List<Review>();
            reviews = context.Review.Include(u=>u.User).Include(p=>p.Product).ToList();
            return reviews;
        }

        public List<Review> GetAllByProdId(int Product_id)
        {
            List<Review> reviews = new List<Review>();
            reviews = context.Review.Include(u => u.User)
                .Where(p => p.ProductId == Product_id).ToList();
            return reviews;
        }
        public Review? GetById(int id)
        {
            return context.Review.FirstOrDefault(r => r.Id == id);
        }

        public void Update(Review entity)
        {
            context.Update(entity);
        }
        public void Save()
        {
           context.SaveChanges();
        }

    }
}
