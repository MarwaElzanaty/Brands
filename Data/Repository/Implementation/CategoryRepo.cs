using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class CategoryRepo : ICategoryRepo,IRepository<Category>
    {
        // Ref from context
        ApplicationDB context;

        // context injected 
        public CategoryRepo(ApplicationDB context)
        {
            this.context = context;
        }

        // crud operations
        public void Add(Category entity)
        {
            context.Add(entity);
        }

        public void Delete(Category entity)
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

        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>();
            list= context.Category.Include(p=>p.Products).ToList();
            return list;
        }

        public Category? GetById(int id)
        {
            return context.Category.SingleOrDefault(d => d.Id == id);
        }

        public void Save()
        {
           context.SaveChanges();
        }

        public void Update(Category entity)
        {
           context.Update(entity);
        }
    }
}
