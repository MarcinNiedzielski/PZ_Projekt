using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PZ_Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeder11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03542356-7e04-4799-9124-a1e927d63628", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "03542356-7e04-4799-9124-a1e927d63628", "f274a51c-071b-457b-8918-2264d7342b04" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "03542356-7e04-4799-9124-a1e927d63628", "f274a51c-071b-457b-8918-2264d7342b04" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03542356-7e04-4799-9124-a1e927d63628");
        }
    }
}
