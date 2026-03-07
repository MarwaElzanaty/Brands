using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class OrderItemRepo : IOrderItemRepo
    {
        // Ref from context
        ApplicationDB context;

        // context injected 
        public OrderItemRepo(ApplicationDB context)
        {
            this.context = context;
        }
        //crud operation
        public void Add(OrderItem entity)
        {
            context.Add(entity);
        }

        public void Delete(OrderItem entity)
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

        public List<OrderItem> GetAll()
        {
           List<OrderItem> orderItems = new List<OrderItem>();
            orderItems= context.OrderItem.Include(o=>o.Order).Include(o=>o.Product).ToList();
            return orderItems;
        }

        public OrderItem? GetById(int id)
        {
            return context.OrderItem.SingleOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(OrderItem entity)
        {
            context.Update(entity);
        }
    }
}
