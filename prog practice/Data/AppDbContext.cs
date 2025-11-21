using Microsoft.EntityFrameworkCore;
using prog_practice.Models;

namespace prog_practice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Roles
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { RoleID = 1, RoleName = "Lecturer" },
                new UserRole { RoleID = 2, RoleName = "ProgrammeCoordinator" },
                new UserRole { RoleID = 3, RoleName = "AcademicManager" },
                new UserRole { RoleID = 4, RoleName = "HR" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, FullName = "John Doe", RoleID = 1, UserEmail = "john@gmail.com", Password = "Password@john1", ContactNumber = "0234567890", HourlyRate = 330m },
                new User { UserID = 2, FullName = "Angel Smith", RoleID = 2, UserEmail = "angel@gmail.com", Password = "Password@angel2", ContactNumber = "098765432", HourlyRate = 300m },
                new User { UserID = 3, FullName = "Musa Keys", RoleID = 3, UserEmail = "musa@gmail.com", Password = "Password@musa3", ContactNumber = "0456789032", HourlyRate = 400m },
                new User { UserID = 7, FullName = "Stephen Curry", RoleID = 4, UserEmail = "steph@gmail.com", Password = "Password@curry30", ContactNumber = "0123456789", HourlyRate = 0m },
                new User { UserID = 8, FullName = "Lebron James", RoleID = 1, UserEmail = "james@gmail.com", Password = "Password@goat1", ContactNumber = "0712345678", HourlyRate = 350m }
                );
            //  Claim → User (Lecturer)
            modelBuilder.Entity<Claim>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.Restrict); //  prevent cascade loops

            //  Review → Claim
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Claim)
                .WithMany()
                .HasForeignKey(r => r.ClaimID)
                .OnDelete(DeleteBehavior.Cascade); // safe to cascade here

            //  Review → User (Reviewer)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.Restrict); // <— this is the key line

            //  Document → Claim
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Claim)
                .WithMany(c => c.Documents)
                .HasForeignKey(d => d.ClaimID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}