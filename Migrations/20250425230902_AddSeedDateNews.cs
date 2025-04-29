using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fruit_Store_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDateNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

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
                    { 6, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn expert tips to select the freshest seasonal fruits at peak flavor and nutrition—straight from local farms to your table.", "How to Choose Seasonal Fruits Like a Pro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }
    }
}
