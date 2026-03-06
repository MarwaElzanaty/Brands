using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocalBrands.Migrations
{
    /// <inheritdoc />
    public partial class dataforrevieww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "Content", "CreatedAt", "ProductId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, "Amazing quality and great fabric, highly recommended!", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, "143f2d00-a63c-43b0-acab-f525e79c6bcf" },
                    { 2, "Very good, but the delivery was slightly delayed.", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, "143f2d00-a63c-43b0-acab-f525e79c6bcf" },
                    { 3, "The design is beautiful and very comfortable to wear.", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, "143f2d00-a63c-43b0-acab-f525e79c6bcf" },
                    { 4, "Acceptable quality considering the price point.", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "143f2d00-a63c-43b0-acab-f525e79c6bcf" },
                    { 5, "Proud to support local brands, world-class craftsmanship!", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, "143f2d00-a63c-43b0-acab-f525e79c6bcf" },
                    { 6, "Excellent experience, I will definitely buy again.", new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5, "143f2d00-a63c-43b0-acab-f525e79c6bcf" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
