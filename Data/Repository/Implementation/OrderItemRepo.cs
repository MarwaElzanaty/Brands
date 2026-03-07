using LocalBrands.Data;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data.Repository.Implementation
{
    public class OrderItemRepo : IOrderItemRepo
    {
        private readonly ApplicationDB _context;

        // Injected context
        public OrderItemRepo(ApplicationDB context)
        {
            _context = context;
        }

        // Add new OrderItem
        public void Add(OrderItem entity)
        {
            _context.OrderItem.Add(entity);
        }

        // Delete by entity
        public void Delete(OrderItem entity)
        {
            _context.OrderItem.Remove(entity);
        }

        // Delete by Id
        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.OrderItem.Remove(item);
            }
        }

        // Get all OrderItems with relations
        public List<OrderItem> GetAll()
        {
            return _context.OrderItem
                           .Include(o => o.Order)
                           .Include(o => o.Product)
                           .ToList();
        }

        // Get single OrderItem with relations
        public OrderItem? GetById(int id)
        {
            return _context.OrderItem
                           .Include(o => o.Order)
                           .Include(o => o.Product)
                           .SingleOrDefault(x => x.Id == id);
        }

        // Save changes
        public void Save()
        {
            _context.SaveChanges();
        }

        // Update entity
        public void Update(OrderItem entity)
        {
            _context.OrderItem.Update(entity);
        }
    }
}