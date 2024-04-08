using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tpBddCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategorieID", "Libelle", "Prix_Km" },
                values: new object[,]
                {
                    { 1, "Categorie X", 35.0 },
                    { 2, "Categorie Y", 35.0 },
                    { 3, "Categorie Z", 35.0 }
                });

            migrationBuilder.InsertData(
                table: "Marques",
                columns: new[] { "MarqueID", "Name" },
                values: new object[,]
                {
                    { 1, "Marque A" },
                    { 2, "Marque B" },
                    { 3, "Marque C" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategorieID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategorieID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategorieID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Marques",
                keyColumn: "MarqueID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Marques",
                keyColumn: "MarqueID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Marques",
                keyColumn: "MarqueID",
                keyValue: 3);
        }
    }
}
