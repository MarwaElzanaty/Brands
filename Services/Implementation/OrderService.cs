using LocalBrands.Data.Repository.Implementation;
using LocalBrands.Data.Repository.Interfaces;
using LocalBrands.Models;
using LocalBrands.Services.Interfaces;

namespace LocalBrands.Services.Implementation
{
    public class OrderService: IOrderService
    {
        IOrderRepo orderRepo;
        public OrderService(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        /// logic of order
        public bool HasUserPurchasedProduct(string userId, int productId)
        {
            
            return orderRepo.GetAll()
                .Any(o => o.UserId == userId &&
                          o.OrderItems.Any(oi => oi.ProductId == productId));
        }
    }
}
