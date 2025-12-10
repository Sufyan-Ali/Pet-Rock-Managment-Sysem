using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetRockManagment.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PetRocks",
                columns: new[] { "id", "bath", "mood", "name" },
                values: new object[,]
                {
                    { 1, true, "happy", "ben" },
                    { 2, false, "sad", "joe" },
                    { 3, true, "angry", "doey" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetRocks",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetRocks",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PetRocks",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
