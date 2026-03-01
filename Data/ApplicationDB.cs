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
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                  
            base.OnConfiguring(optionsBuilder);

        }

    }
}
