using System.ComponentModel.DataAnnotations.Schema;

namespace LocalBrands.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
