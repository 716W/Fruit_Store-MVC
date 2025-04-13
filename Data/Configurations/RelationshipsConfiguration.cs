using Fruit_Store_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Fruit_Store_MVC.Data.Configurations
{
    public class RelationshipsConfiguration
    {
        public static void Apply(ModelBuilder builder)
        {
            // |-- Apply the configurations for All relationships here --|

            // --------------------------------------
            //---------- Relationships --------------
            //---------------------------------------

            // ------------- Order -----------------

            // Order has many OrderItems & OrderItem belongs to an Order
            builder.Entity<Order>().HasMany(x => x.OrderItems)
               .WithOne(x => x.Order)
               .HasForeignKey(x => x.OrderId);

            // Order has one User & User has many Orders
            //builder.Entity<Order>().HasOne(x => x.User)
            //    .WithMany(x => x.Users)
            //    .HasForeignKey(x => x.UserId);

            // Order has one Coupon & Coupon has many Orders
            builder.Entity<Order>().HasOne(x => x.Coupon)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CouponId)
                .IsRequired(false);

            //-------------------------------------
            // ------------- Category -------------

            // Category has many Products & Product belongs to a Category
            builder.Entity<Category>().HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();

            // Also u can say the category has Coupons  and not just the products (Feature) .
            //-------------------------------------
            // ------------- Product -------------

            // Product has many OrderItems & OrderItem belongs to a Product
            // One To Many Relationship

            builder.Entity<Product>().HasMany(x => x.OrderItems)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            // Product has many Reviews & Review belongs to a Product
            // One To Many Relationship

            builder.Entity<Product>().HasMany(x => x.Reviews)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            // -------------------------------------
            // ------------- User -----------------
            // User has many Orders & Order belongs to a User
            // User has many Reviews & Review belongs to a User
            // I'll implemnted after add Identity , cause i need to add the IdentityUser class and inherit from it 

            //------------------------------------




        }
    }
}
