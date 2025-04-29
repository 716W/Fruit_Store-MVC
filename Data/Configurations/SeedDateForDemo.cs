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
            //modelBuilder.Entity<Product>().HasData(
            //     //Fruits Categories
            //     new Product
            //     {
            //         Id = 1,
            //         Name = "Strawberry",
            //         Description = "Wow, your strawberry is super fresh and juicy!",
            //         Price = 4.50m,
            //         Quantity = 100,
            //         ImageUrl = "Images/Products/Fruits/Strawberry.jpg",
            //         CategoryId = 1
            //     },
            //     new Product
            //     {
            //         Id = 2,
            //         Name = "Grapes",
            //         Description = "Sweet little bites of happiness — great chilled or fresh off the vine!",
            //         Price = 3.80m,
            //         Quantity = 100,
            //         ImageUrl = "Images/Products/Fruits/black-grapes.jpg",
            //         CategoryId = 1
            //     },
            //     new Product
            //     {
            //         Id = 3,
            //         Name = "lemon",
            //         Description = "Bright and zesty — the citrus spark every dish needs!",
            //         Price = 2.00m,
            //         Quantity = 100,
            //         ImageUrl = "Images/Products/Fruits/lemon.jpg",
            //         CategoryId = 1
            //     },
            //     new Product
            //     {
            //         Id = 4,
            //         Name = "kiwi",
            //         Description = "Fuzzy outside, vibrant inside — sweet and tangy delight!",
            //         Price = 3.00m,
            //         Quantity = 100,
            //         ImageUrl = "Images/Products/Fruits/kiwi.jpg",
            //         CategoryId = 1
            //     },
            //    new Product
            //    {
            //        Id = 5,
            //        Name = "Apple",
            //        Description = "A great green apple — crisp, clean, and classic!",
            //        Price = 2.50m,
            //        Quantity = 100,
            //        ImageUrl = "Images/Products/Fruits/apple.jpg",
            //        CategoryId = 1
            //    },
            //    new Product
            //    {
            //        Id = 6,
            //        Name = "Red-Raspberries",
            //        Description = "Soft, tart, and oh-so-satisfying — like tiny red gems!",
            //        Price = 5.00m,
            //        Quantity = 100,
            //        ImageUrl = "Images/Products/Fruits/red-raspberries.jpg",
            //        CategoryId = 1
            //    },
            //    // Vigetables Categories
            //    new Product
            //    {
            //        Id = 7,
            //        Name = "Carrot",
            //        Description = "Crunchy and sweet — the classic orange powerhouse!",
            //        Price = 1.50m,
            //        Quantity = 200,
            //        ImageUrl = "Images/Products/Vigetables/Carrot.jpg",
            //        CategoryId = 2
            //    },
            //    new Product
            //    {
            //        Id = 8,
            //        Name = "Broccoli",
            //        Description = "Bright green and full of goodness — a little tree of health!",
            //        Price = 2.20m,
            //        Quantity = 200,
            //        ImageUrl = "Images/Products/Vigetables/Broccoli.jpg",
            //        CategoryId = 2
            //    },
            //    new Product
            //    {
            //        Id = 9,
            //        Name = "Tomato",
            //        Description = "Juicy and rich — perfect for your next recipe or snack!",
            //        Price = 2.00m,
            //        Quantity = 200,
            //        ImageUrl = "Images/Products/Vigetables/Tomato.jpg",
            //        CategoryId = 2
            //    },
            //    new Product
            //    {
            //        Id = 10,
            //        Name = "Spinach",
            //        Description = "Fresh and leafy — packed with nutrients and perfect for any dish!",
            //        Price = 2.50m,
            //        Quantity = 200,
            //        ImageUrl = "Images/Products/Veggies/Spinach.jpg", 
            //        CategoryId = 2
            //    },
            //    new Product
            //    {
            //        Id = 11,
            //        Name = "Cucumber",
            //        Description = "Cool, crisp, and refreshing — ideal for salads and snacking!",
            //        Price = 1.80m,
            //        Quantity = 200,
            //        ImageUrl = "Images/Products/Vigetables/Cucumber.jpg",
            //        CategoryId = 2
            //    },
            //    new Product
            //    {
            //        Id = 12,
            //        Name = "Bell Pepper",
            //        Description = "Colorful and crunchy — nature’s sweet and savory combo!",
            //        Price = 3.00m,
            //        Quantity = 200,
            //        ImageUrl = "Images/Products/Vigetables/Bell-Pepper.jpg",
            //        CategoryId = 2
            //    }
            //);

            //// News
            modelBuilder.Entity<New>().HasData(
                new New
                {
                    Id = 1,
                    Title = "You will vainly look for fruit on it in autumn.",
                    Description = "Strawberries shine in spring and early summer, reminding us that every fruit has its season. Seeking them in autumn is a lesson in nature’s timing and patience."
                },
                new New
                {
                    Id = 2,
                    Title = "A man's worth has its season, like tomato.",
                    Description = "Just like tomatoes ripen in their own time, people bloom in their season. A beautiful blend of fruit imagery and life wisdom, paired with the freshness of variety."
                },
                new New
                {
                    Id = 3,
                    Title = "Good thoughts bear good fresh juicy fruit.",
                    Description = "Much like the healthy ripeness of vineyard grapes, positivity nourishes fruitful outcomes. Choose optimism—harvest wellness."
                },
                new New
                {
                    Id = 4,
                    Title = "Fruitkha Launches Organic Delivery Service",
                    Description = "Experience the taste of nature with our new farm-to-door delivery. Hand-picked, organic fruits now available online!"
                },
                new New
                {
                    Id = 5,
                    Title = "Top 5 Fruits to Boost Your Immunity This Season",
                    Description = "Discover the top fruits that can naturally strengthen your immune system—featuring citrus, berries, and more."
                },
                new New
                {
                    Id = 6,
                    Title = "How to Choose Seasonal Fruits Like a Pro",
                    Description = "Learn expert tips to select the freshest seasonal fruits at peak flavor and nutrition—straight from local farms to your table."
                }
            );


            //// Coupons
            //modelBuilder.Entity<Coupon>().HasData(
            //    new Coupon
            //    {
            //        Id = 1,
            //        Code = "FRUIT10",
            //        DiscountPercentage = 10,
            //        ExpiryDate = DateTime.UtcNow.AddMonths(1)
            //    },
            //    new Coupon
            //    {
            //        Id = 2,
            //        Code = "VIGETABLE1",
            //        DiscountPercentage = 5,
            //        ExpiryDate = DateTime.UtcNow.AddMonths(1)
            //    }
            //);

            //// Orders
            //modelBuilder.Entity<Order>().HasData(
            //    new Order
            //    {
            //        Id = 1,
            //        OrderDate = DateTime.UtcNow,
            //        TotalAmount = 19.99m,
            //        Status = Enums.OrderStatus.Delivered,
            //        CouponId = 1,
            //        UserId = null // Assuming you have a user ID to associate with the review
            //    }
            //);

            ////OredrItems
            //modelBuilder.Entity<OrderItem>().HasData(
            //    new OrderItem { OrderId = 1, ProductId = 1, Quantity = 5, UnitPrice = 5 },
            //    new OrderItem { OrderId = 2, ProductId = 2, Quantity = 10, UnitPrice = 7 },
            //    new OrderItem { OrderId = 3, ProductId = 3, Quantity = 15, UnitPrice = 10 }
            //);

            // Reviews
            //modelBuilder.Entity<Review>().HasData(
            //    new Review
            //    {
            //        Id = 1,
            //        Text = "Great apple!",
            //        CreatedDate = DateTime.UtcNow,
            //        ProductId = 1,
            //        UserId = null
            //    },
            //    new Review
            //    {
            //        Id = 2,
            //        Text = "Wow! Your products are so fresh and delicious.",
            //        CreatedDate = DateTime.UtcNow,
            //        ProductId = 2,
            //        UserId = null
            //    }
            //);
        }
    }

}