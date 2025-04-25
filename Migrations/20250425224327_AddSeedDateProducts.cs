using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fruit_Store_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 10, 2, "Fresh and leafy — packed with nutrients and perfect for any dish!", "Images/Products/Vigetables/Spinach.jpg", "Spinach", 2.50m, 200 },
                    { 11, 2, "Cool, crisp, and refreshing — ideal for salads and snacking!", "Images/Products/Vigetables/Cucumber.jpg", "Cucumber", 1.80m, 200 },
                    { 12, 2, "Colorful and crunchy — nature’s sweet and savory combo!", "Images/Products/Vigetables/Bell-Pepper.jpg", "Bell Pepper", 3.00m, 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

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
        }
    }
}
