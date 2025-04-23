using Fruit_Store_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Fruit_Store_MVC.Data.Configurations
{
    public static class SeedData
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fruits" },
                new Category { Id = 2, Name = "Vegetables" }
            );

            // Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Apple",
                    Description = "Fresh Red Apple",
                    Price = 1.99m,
                    Quantity = 100,
                    ImageUrl = "Images/Products/apple.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Carrot",
                    Description = "Organic Carrot",
                    Price = 0.99m,
                    Quantity = 200,
                    ImageUrl = "Images/Products/carrot.jpg",
                    CategoryId = 2
                }
            );

            // News
            modelBuilder.Entity<New>().HasData(
                new New { Id = 1, Title = "Welcome", Description = "Grand opening of the Fruit Store!" }
            );

            // Coupons
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = 1,
                    Code = "FRUIT10",
                    DiscountPercentage = 10,
                    ExpiryDate = DateTime.UtcNow.AddMonths(1)
                }
            );

            // Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    TotalAmount = 19.99m,
                    Status = Enums.OrderStatus.Delivered,
                    CouponId = 1,
                    //UserId = "user-1" // تأكد أن هذا ID موجود من IdentityUser
                }
            );

            // OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderId = 1, ProductId = 1, Quantity = 5 , UnitPrice =  5},
                new OrderItem { OrderId = 2, ProductId = 2, Quantity = 10 ,UnitPrice =  7}
            );

            // Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    Text = "Great apple!",
                    CreatedDate = DateTime.UtcNow,
                    ProductId = 1,
                    //UserId = "user-1"
                }
            );
        }
    }

}
