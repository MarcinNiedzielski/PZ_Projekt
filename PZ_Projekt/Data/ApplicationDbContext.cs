using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PZ_Projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PZ_Projekt.Models.Product> Product { get; set; } = default!;
        public DbSet<PZ_Projekt.Models.Item> Item { get; set; } = default!;
    }
}
