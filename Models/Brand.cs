namespace LocalBrands.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual List<Product>? Products { get; set; }
    }
}
