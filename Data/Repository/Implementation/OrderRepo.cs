using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDB context;

        // context injected
        public OrderRepo(ApplicationDB context)
        {
            this.context = context;
        }

        // CRUD operations
        public void Add(Order entity)
        {
            context.Order.Add(entity);
        }

        public void Delete(Order entity)
        {
            context.Order.Remove(entity);
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                context.Order.Remove(item);
            }
        }

        public List<Order> GetAll()
        {
            return context.Order
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product) 
                .Include(o => o.Payment)
                .ToList();
        }

        public Order? GetById(int id)
        {
            return context.Order
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product) 
                .Include(o => o.Payment)
                .SingleOrDefault(o => o.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Order entity)
        {
            context.Order.Update(entity);
        }
    }
}