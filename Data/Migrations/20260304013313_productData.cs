using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocalBrands.Migrations
{
    /// <inheritdoc />
    public partial class productData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CategoryId", "Description", "Name", "PictureUrl", "Price", "Rating", "SalesCount", "createdAt" },
                values: new object[,]
                {
                    { 2, 4, 1, "100% Cotton", "Casual T-Shirt", "img2.jpg", 450m, 4.0, 25, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4, 1, "Perfect for parties", "Evening Dress", "img3.jpg", 2500m, 5.0, 5, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 5, 2, "Pure silver 925", "Silver Necklace", "img4.jpg", 800m, 4.0, 15, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, 1, "Winter collection", "Classic Jacket", "img5.jpg", 1800m, 5.0, 8, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 5, 2, "Water resistant", "Modern Watch", "img6.jpg", 3200m, 4.0, 12, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4, 1, "Soft touch", "Silk Scarf", "img7.jpg", 350m, 3.0, 30, new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 5, 2, "18k Gold", "Gold Ring", "img8.jpg", 5000m, 5.0, 3, new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 3, 2, "Genuine leather", "Leather Belt", "img9.jpg", 600m, 4.0, 20, new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 4, 1, "Slim fit", "Denim Jeans", "img10.jpg", 950m, 4.0, 18, new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 3, 1, "Warm for winter", "Woolen Hat", "img11.jpg", 250m, 3.0, 40, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 5, 2, "Luxury edition", "Designer Handbag", "img12.jpg", 4200m, 5.0, 7, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 3, 1, "Cozy fit", "Cotton Hoodie", "img1.jpg", 1200m, 4.0, 15, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 4, 1, "Comfortable for running", "Sport Shoes", "img2.jpg", 2200m, 5.0, 10, new DateTime(2026, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 5, 2, "Stylish sun protection", "Summer Cap", "img3.jpg", 300m, 3.0, 50, new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
