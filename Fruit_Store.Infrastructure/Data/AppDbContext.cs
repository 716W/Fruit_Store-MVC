using FruitStore.Core.Models;
using FruitStore.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FruitStore.Fruit_Store.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base method to ensure the default Identity model is created
            base.OnModelCreating(modelBuilder);

            // Apply configurations for each entity
            // Every class that implements IEntityTypeConfiguration<T> should be added here
            // every calss has roles for every entity

            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderItemConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new NewsConfig());
            modelBuilder.ApplyConfiguration(new CuponConfig());

            // add class to apply realtions between entities
            RelationshipsConfiguration.Apply(modelBuilder);

            // seed data for Demo and test .
            SeedData.Seed(modelBuilder);
        }

        // Create Model :
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Coupon> Coupons { get; set; }


    }
}
