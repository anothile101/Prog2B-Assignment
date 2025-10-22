using Microsoft.EntityFrameworkCore;
using prog_practice.Models;

namespace prog_practice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // This will create a "Claims" table in your database
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimHistory> ClaimHistories { get; set; }
    }
}