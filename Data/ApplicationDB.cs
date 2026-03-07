using LocalBrands.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocalBrands.Data
{
    public class ApplicationDB : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDB() { }
        public ApplicationDB(DbContextOptions options) : base(options) { }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Payment> Payment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.Payment).WithOne(p => p.Order)
           .HasForeignKey<Payment>(p => p.OrderId);

            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Payment>().ToTable("Order");
            modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Payment>().Property(p => p.Amount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderItem>().Property(o => o.PriceAtPurchase).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 2, Name = "Casual T-Shirt", Price = 450, Description = "100% Cotton", PictureUrl = "img2.jpg", Rating = 4, BrandId = 4, CategoryId = 1, SalesCount = 25, createdAt = DateTime.Parse("2026-01-05") },
                new Product { Id = 3, Name = "Evening Dress", Price = 2500, Description = "Perfect for parties", PictureUrl = "img3.jpg", Rating = 5, BrandId = 4, CategoryId = 1, SalesCount = 5, createdAt = DateTime.Parse("2026-01-10") },
                new Product { Id = 4, Name = "Silver Necklace", Price = 800, Description = "Pure silver 925", PictureUrl = "img4.jpg", Rating = 4, BrandId = 5, CategoryId = 2, SalesCount = 15, createdAt = DateTime.Parse("2026-01-12") },
                new Product { Id = 5, Name = "Classic Jacket", Price = 1800, Description = "Winter collection", PictureUrl = "img5.jpg", Rating = 5, BrandId = 3, CategoryId = 1, SalesCount = 8, createdAt = DateTime.Parse("2026-01-15") },
                new Product { Id = 6, Name = "Modern Watch", Price = 3200, Description = "Water resistant", PictureUrl = "img6.jpg", Rating = 4, BrandId = 5, CategoryId = 2, SalesCount = 12, createdAt = DateTime.Parse("2026-01-20") },
                new Product { Id = 7, Name = "Silk Scarf", Price = 350, Description = "Soft touch", PictureUrl = "img7.jpg", Rating = 3, BrandId = 4, CategoryId = 1, SalesCount = 30, createdAt = DateTime.Parse("2026-01-25") },
                new Product { Id = 8, Name = "Gold Ring", Price = 5000, Description = "18k Gold", PictureUrl = "img8.jpg", Rating = 5, BrandId = 5, CategoryId = 2, SalesCount = 3, createdAt = DateTime.Parse("2026-01-28") },
                new Product { Id = 9, Name = "Leather Belt", Price = 600, Description = "Genuine leather", PictureUrl = "img9.jpg", Rating = 4, BrandId = 3, CategoryId = 2, SalesCount = 20, createdAt = DateTime.Parse("2026-02-01") },
                new Product { Id = 10, Name = "Denim Jeans", Price = 950, Description = "Slim fit", PictureUrl = "img10.jpg", Rating = 4, BrandId = 4, CategoryId = 1, SalesCount = 18, createdAt = DateTime.Parse("2026-02-05") },
                new Product { Id = 11, Name = "Woolen Hat", Price = 250, Description = "Warm for winter", PictureUrl = "img11.jpg", Rating = 3, BrandId = 3, CategoryId = 1, SalesCount = 40, createdAt = DateTime.Parse("2026-02-10") },
                new Product { Id = 12, Name = "Designer Handbag", Price = 4200, Description = "Luxury edition", PictureUrl = "img12.jpg", Rating = 5, BrandId = 5, CategoryId = 2, SalesCount = 7, createdAt = DateTime.Parse("2026-02-15") },
                new Product { Id = 13, Name = "Cotton Hoodie", Price = 1200, Description = "Cozy fit", PictureUrl = "img1.jpg", Rating = 4, BrandId = 3, CategoryId = 1, SalesCount = 15, createdAt = DateTime.Parse("2026-02-20") },
                new Product { Id = 14, Name = "Sport Shoes", Price = 2200, Description = "Comfortable for running", PictureUrl = "img2.jpg", Rating = 5, BrandId = 4, CategoryId = 1, SalesCount = 10, createdAt = DateTime.Parse("2026-02-22") },
                new Product { Id = 15, Name = "Summer Cap", Price = 300, Description = "Stylish sun protection", PictureUrl = "img3.jpg", Rating = 3, BrandId = 5, CategoryId = 2, SalesCount = 50, createdAt = DateTime.Parse("2026-02-25") }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, Content = "Amazing quality and great fabric, highly recommended!", Rating = 5, CreatedAt = new DateTime(2026, 3, 6), UserId = "143f2d00-a63c-43b0-acab-f525e79c6bcf", ProductId = 1 },
                new Review { Id = 2, Content = "Very good, but the delivery was slightly delayed.", Rating = 4, CreatedAt = new DateTime(2026, 3, 6), UserId = "143f2d00-a63c-43b0-acab-f525e79c6bcf", ProductId = 2 },
                new Review { Id = 3, Content = "The design is beautiful and very comfortable to wear.", Rating = 5, CreatedAt = new DateTime(2026, 3, 6), UserId = "143f2d00-a63c-43b0-acab-f525e79c6bcf", ProductId = 3 },
                new Review { Id = 4, Content = "Acceptable quality considering the price point.", Rating = 3, CreatedAt = new DateTime(2026, 3, 6), UserId = "143f2d00-a63c-43b0-acab-f525e79c6bcf", ProductId = 4 },
                new Review { Id = 5, Content = "Proud to support local brands, world-class craftsmanship!", Rating = 5, CreatedAt = new DateTime(2026, 3, 6), UserId = "143f2d00-a63c-43b0-acab-f525e79c6bcf", ProductId = 5 },
                new Review { Id = 6, Content = "Excellent experience, I will definitely buy again.", Rating = 5, CreatedAt = new DateTime(2026, 3, 6), UserId = "143f2d00-a63c-43b0-acab-f525e79c6bcf", ProductId = 6 }

                );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            base.OnConfiguring(optionsBuilder);
        }

    }
}
