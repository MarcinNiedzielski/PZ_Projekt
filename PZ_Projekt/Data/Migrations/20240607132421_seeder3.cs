using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PZ_Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeder3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "GPU", "Szukasz uniwersalnej karty graficznej w przystępnej cenie, która wykazywać się będzie wysokim standardem? MSI GeForce RTX 4070 Ti Ventus 2X 12G jest bardzo przyzwoitą opcją, która spełni oczekiwania praktycznie każdego użytkownika – niezależnie od tego, czy Twój PC ma służyć do profesjonalnego grania, pracy, czy też do tworzenia kreatywnych projektów.", "/uploads/503414e8-2efb-4cbb-8e1c-fcca2bd46612.jpg", "Karta graficzna MSI GeForce RTX 4070", 3300m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
