using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fruit_Store_MVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataToStatic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fruits" },
                    { 2, "Vigetables" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "DiscountPercentage", "ExpiryDate" },
                values: new object[,]
                {
                    { 1, "FRUIT10", 10m, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "VIGETABLE1", 5m, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedDate", "Description", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strawberries shine in spring and early summer, reminding us that every fruit has its season. Seeking them in autumn is a lesson in nature’s timing and patience.", "You will vainly look for fruit on it in autumn." },
                    { 2, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Just like tomatoes ripen in their own time, people bloom in their season. A beautiful blend of fruit imagery and life wisdom, paired with the freshness of variety.", "A man's worth has its season, like tomato." },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Much like the healthy ripeness of vineyard grapes, positivity nourishes fruitful outcomes. Choose optimism—harvest wellness.", "Good thoughts bear good fresh juicy fruit." },
                    { 4, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experience the taste of nature with our new farm-to-door delivery. Hand-picked, organic fruits now available online!", "Fruitkha Launches Organic Delivery Service" },
                    { 5, new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discover the top fruits that can naturally strengthen your immune system—featuring citrus, berries, and more.", "Top 5 Fruits to Boost Your Immunity This Season" },
                    { 6, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn expert tips to select the freshest seasonal fruits at peak flavor and nutrition—straight from local farms to your table.", "How to Choose Seasonal Fruits Like a Pro" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CouponId", "OrderDate", "Status", "TotalAmount", "UserId" },
                values: new object[] { 1, 1, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 19.99m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Wow, your strawberry is super fresh and juicy!", "Images/Products/Fruits/Strawberry.jpg", "Strawberry", 4.50m, 100 },
                    { 2, 1, "Sweet little bites of happiness — great chilled or fresh off the vine!", "Images/Products/Fruits/black-grapes.jpg", "Grapes", 3.80m, 100 },
                    { 3, 1, "Bright and zesty — the citrus spark every dish needs!", "Images/Products/Fruits/lemon.jpg", "lemon", 2.00m, 100 },
                    { 4, 1, "Fuzzy outside, vibrant inside — sweet and tangy delight!", "Images/Products/Fruits/kiwi.jpg", "kiwi", 3.00m, 100 },
                    { 5, 1, "A great green apple — crisp, clean, and classic!", "Images/Products/Fruits/apple.jpg", "Apple", 2.50m, 100 },
                    { 6, 1, "Soft, tart, and oh-so-satisfying — like tiny red gems!", "Images/Products/Fruits/red-raspberries.jpg", "Red-Raspberries", 5.00m, 100 },
                    { 7, 2, "Crunchy and sweet — the classic orange powerhouse!", "Images/Products/Vigetables/Carrot.jpg", "Carrot", 1.50m, 200 },
                    { 8, 2, "Bright green and full of goodness — a little tree of health!", "Images/Products/Vigetables/Broccoli.jpg", "Broccoli", 2.20m, 200 },
                    { 9, 2, "Juicy and rich — perfect for your next recipe or snack!", "Images/Products/Vigetables/Tomato.jpg", "Tomato", 2.00m, 200 },
                    { 10, 2, "Fresh and leafy — packed with nutrients and perfect for any dish!", "Images/Products/Veggies/Spinach.jpg", "Spinach", 2.50m, 200 },
                    { 11, 2, "Cool, crisp, and refreshing — ideal for salads and snacking!", "Images/Products/Vigetables/Cucumber.jpg", "Cucumber", 1.80m, 200 },
                    { 12, 2, "Colorful and crunchy — nature’s sweet and savory combo!", "Images/Products/Vigetables/Bell-Pepper.jpg", "Bell Pepper", 3.00m, 200 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreatedDate", "ProductId", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Great apple!", null },
                    { 2, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Wow! Your products are so fresh and delicious.", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "News",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
