using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PZ_Projekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeder10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e70a9c29-ca05-41d6-aa4a-f876f9ed833f", 0, "d25bb904-d2ad-489d-906b-f58fcf737e6e", "a@a.com", true, true, null, "A@A.COM", "A@A.COM", "AQAAAAIAAYagAAAAEAwVc2aVRiKlYfqvPyiY6ZobmecB15it3IRUmboduoLCvZlZPiKhaJPrtVSbjXcxVQ==", null, false, "BBXP2X4LWHMYHRI33EGOAGAX4TK5KR56", false, "a@a.com" },
                    { "f274a51c-071b-457b-8918-2264d7342b04", 0, "849a9e5f-4516-430e-acfd-864e1cea920f", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEMwDf+gJp4KV3KrBQDzbMOJN0HNOAGZi51iqGZ82qFr1cuXkxqKAy5D7oCPcA1O+mw==", null, false, "DPZHW7DGCJFC6ZF6WYKNBF2IJBOI6WXZ", false, "admin@admin.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e70a9c29-ca05-41d6-aa4a-f876f9ed833f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f274a51c-071b-457b-8918-2264d7342b04");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "fa28f0d0-5ea9-4d83-95a0-be5be55fceec", "a@a.com", true, false, null, "A@A.COM", "A@A.COM", "AQAAAAIAAYagAAAAELRKn3JxG7vCFQmWrBHP3MJA+iUYYRxmqmEJKdDt+EtHq8R8lcKYd7FzKL6UFpEA/g==", null, false, "11c882d7-4a60-4d4c-9ad9-e641bda07d59", false, "a@a.com" },
                    { "2", 0, "3cd873ef-9e4d-4a12-97ef-bab92650de2f", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEAVhU5O08QHyxE8kUH4Kl+1wFcMlVLKeAuWCQUxhnsN65sHXsB4Z9D/D4ME6gVY6dQ==", null, false, "d66d0190-d343-4190-8bb6-3e5f315cc384", false, "admin@admin.com" }
                });
        }
    }
}
