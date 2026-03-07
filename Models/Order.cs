using System.ComponentModel.DataAnnotations.Schema;

namespace LocalBrands.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } 
        public decimal TotalAmount { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public Payment Payment { get; set; }
        public string ShippingAddress { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Method { get; set; }
        public string? StripeSessionId { get; set; }
    }
}
