using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class ProductRepo : IProductRepo,IRepository<Product>
    {
        // Ref from context
         ApplicationDB context;

        // context injected 
        public ProductRepo(ApplicationDB context)
        {
            this.context = context;
        }
        // crud operations
        public void Add(Product entity)
        {
            context.Add(entity);
        }

        public void Delete(Product entity)
        {
            context.Remove(entity);
        }
        public void DeleteById(int id)
        {
            var item=GetById(id);
            if (item != null)
            {
                context.Remove(item);
            }
        }
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            products= context.Product
                .Include(b=>b.Brand)
                .Include(c=>c.Category)
                .Include(c=>c.CartItems)
                .Include(o=>o.OrderItems)
                .Include(r=>r.Reviews)
                .ToList();
            return products;
        }
        public Product? GetById(int id)
        {
            return context.Product.Include(p => p.Brand)
                .Include(c => c.Category)
                .Include(c => c.CartItems)
                .Include(o => o.OrderItems)
                .Include(r => r.Reviews).FirstOrDefault(p => p.Id == id);
        }
        public void Save()
        {
           context.SaveChanges();
        }
        public void Update(Product entity)
        {
           context.Update(entity);
        }
    }
}
