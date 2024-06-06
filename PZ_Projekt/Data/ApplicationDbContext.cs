using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PZ_Projekt.Models;

namespace PZ_Projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PZ_Projekt.Models.Item> Item { get; set; } = default!;
        public DbSet<PZ_Projekt.Models.Cart> Cart { get; set; }
        public DbSet<PZ_Projekt.Models.CartItem> CartItem { get; set; }
        public DbSet<PZ_Projekt.Models.Order> Order { get; set; }
        public DbSet<PZ_Projekt.Models.OrderItem> OrderItem { get; set; }
    }
}
