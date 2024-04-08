using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tpBddCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Voitures",
                columns: new[] { "VoitureID", "CategorieID", "Couleur", "Immat", "MarqueID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Rouge", "123-ABC", 1, "Voiture A" },
                    { 2, 2, "Bleu", "456-DEF", 2, "Voiture B" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Voitures",
                keyColumn: "VoitureID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Voitures",
                keyColumn: "VoitureID",
                keyValue: 2);
        }
    }
}
