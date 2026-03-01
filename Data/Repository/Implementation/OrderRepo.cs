using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class OrderRepo : IOrderRepo, IRepository<Order>
    {
        // Ref from context
        ApplicationDB context;

        // context injected 
        public OrderRepo(ApplicationDB context)
        {
            this.context = context;
        }
        // crud operations
        public void Add(Order entity)
        {
            context.Add(entity);
        }

        public void Delete(Order entity)
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

        public List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();
            orders = context.Order
                .Include(u => u.User)
                .Include(o => o.OrderItems)
                .Include(p => p.Payment)
                .ToList();
            return orders;
        }

        public Order? GetById(int id)
        {
            return context.Order.SingleOrDefault(d => d.Id == id);
        }

        public void Save()
        {
           context.SaveChanges();
        }

        public void Update(Order entity)
        {
            context.Update(entity);
        }
    }
}
