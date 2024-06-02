using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PZ_Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemEnhanced : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Item",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Item");
        }
    }
}
