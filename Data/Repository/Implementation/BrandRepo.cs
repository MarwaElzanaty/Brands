using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class BrandRepo : IBrandRepo
    {
        // Ref from context
        ApplicationDB context;

        // context injected via constructor
        public BrandRepo(ApplicationDB context)
        {
            this.context = context;
        }

        public void Add(Brand entity)
        {
            context.Add(entity);
        }

        public void Delete(Brand entity)
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

        public List<Brand> GetAll()
        {
            List<Brand> list = new List<Brand>();
            list= context.Brand.Include(p=>p.Products).ToList();
            return list;
        }

        public Brand? GetById(int id)
        {
            return context.Brand.SingleOrDefault(b => b.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Brand entity)
        {
            context.Update(entity); 
        }
    }
}
