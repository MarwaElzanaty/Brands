using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class CategoryRepo : ICategoryRepo //IRepository<Category>
    {
        private readonly ApplicationDB context;
        public CategoryRepo(ApplicationDB context)
        {
            this.context = context;
        }

        public List<Category> GetAll()
        {
            return context.Category.Include(c => c.Products).ToList();
        }

        public Category? GetById(int id)
        {
            return context.Category.Include(c => c.Products).ThenInclude(p => p.Brand) .Include(c => c.Brands)       .SingleOrDefault(c => c.Id == id);
        }

        // crud operations
        public void Add(Category entity)
        {
            context.Category.Add(entity);
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                context.Category.Remove(item);
            }
        }
        public void Save()
        {
           context.SaveChanges();
        }
        public void Update(Category entity)
        {
            //
        }

        public void Delete(Category entity)
        {
           //
        }

    }
}
