using System.ComponentModel.DataAnnotations.Schema;

namespace LocalBrands.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public double Rating { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<CartItem>? CartItems { get; set; }
        public virtual List<OrderItem>? OrderItems { get; set; }
        public virtual List<Review>? Reviews { get; set; }
    }
}
