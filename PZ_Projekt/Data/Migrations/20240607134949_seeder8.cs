using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PZ_Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeder8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa28f0d0-5ea9-4d83-95a0-be5be55fceec", "AQAAAAIAAYagAAAAELRKn3JxG7vCFQmWrBHP3MJA+iUYYRxmqmEJKdDt+EtHq8R8lcKYd7FzKL6UFpEA/g==", "11c882d7-4a60-4d4c-9ad9-e641bda07d59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cd873ef-9e4d-4a12-97ef-bab92650de2f", "AQAAAAIAAYagAAAAEAVhU5O08QHyxE8kUH4Kl+1wFcMlVLKeAuWCQUxhnsN65sHXsB4Z9D/D4ME6gVY6dQ==", "d66d0190-d343-4190-8bb6-3e5f315cc384" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "402cdbbf-ea7c-4091-91dd-2eb64ef66221", "AQAAAAIAAYagAAAAEH1i+Ji6a7949LOS+qaAu5EN1LkDQOVTrh4XfTqB2NMo5ttFjHsW11VZeXMYKBpB4Q==", "b0ddab66-e7c3-4f47-b9c3-059a08aa020b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7021e5f0-ac7c-4d76-afbf-476e8cce22e3", "AQAAAAIAAYagAAAAEIVupsQTHfX6N3714oM0echNvNSQ4mPJI3vi5qpy3zSDgtUdZG7hLctZ8ygXXfNdwg==", "5101ea33-1a1b-4d74-8860-c33eeaaff302" });
        }
    }
}
