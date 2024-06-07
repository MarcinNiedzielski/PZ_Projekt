using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PZ_Projekt.Data;
using PZ_Projekt.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager)
    {
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            if (context.Item.Any())
            {
                return;   // DB has been seeded
            }

            context.Item.AddRange(
                new Item
                {
                    Name = "Karta graficzna MSI GeForce RTX 4070",
                    Category = "GPU",
                    Description = "Szukasz uniwersalnej karty graficznej w przystępnej cenie, która wykazywać się " +
                    "będzie wysokim standardem? MSI GeForce RTX 4070 Ti Ventus 2X 12G jest bardzo przyzwoitą opcją, która spełni oczekiwania praktycznie każdego użytkownika – " +
                    "niezależnie od tego, czy Twój PC ma służyć do profesjonalnego grania, pracy, czy też do tworzenia kreatywnych projektów.",

                    Price = 3300M,
                    ImageUrl = "/uploads/503414e8-2efb-4cbb-8e1c-fcca2bd46612.jpg"
                }

            ); 

            await context.SaveChangesAsync();

            // Seed users
            var testUser = new IdentityUser { UserName = "test@example.com", Email = "test@example.com" };
            await userManager.CreateAsync(testUser, "Test@123");

            // Seed roles and assign to users
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admininistrator", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminUser = new IdentityUser { UserName = "admin@example.com", Email = "admin@example.com" };
            var createAdminUser = await userManager.CreateAsync(adminUser, "Admin@123");
            if (createAdminUser.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
