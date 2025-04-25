using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fruit_Store_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDateCoupons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "DiscountPercentage", "ExpiryDate", "IsActived" },
                values: new object[] { 1, "FRUIT10", 10m, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "DiscountPercentage", "ExpiryDate" },
                values: new object[] { 2, "VIGETABLE1", 5m, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
