using Microsoft.EntityFrameworkCore;
using AirWAD.Models.DataBase;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AirWAD
{
    public class AirWADContext : IdentityDbContext<IdentityUser>
    {
        public AirWADContext(DbContextOptions<AirWADContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<UserStatistics> UserStatistics { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ListingStatistics> ListingStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<User>()
                .HasOne(a => a.UserStatistics)
                .WithOne(b => b.User)
                .HasForeignKey<UserStatistics>(b => b.UserID);
                */
        }
    }
}
