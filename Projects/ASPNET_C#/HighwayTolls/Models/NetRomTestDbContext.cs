using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HighwayTolls.Models
{
    public partial class NetRomTestDbContext : IdentityDbContext<Employee>
    {
        public NetRomTestDbContext()
        {
        }

        public NetRomTestDbContext(DbContextOptions<NetRomTestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<TollBooth> TollBooths { get; set; }
        public virtual DbSet<TollLocation> TollLocations { get; set; }
        public virtual DbSet<TollPayment> TollPayments { get; set; }
        public virtual DbSet<TollPrice> TollPrices { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<TripPayment> TripPayments { get; set; }
        public virtual DbSet<TripPrice> TripPrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("AspNetUsers");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.TollBooth)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.TollBoothId)
                    .HasConstraintName("FK_TollBooth_Employee");
            });

            modelBuilder.Entity<TollBooth>(entity =>
            {
                entity.ToTable("TollBooth");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.TollLocation)
                    .WithMany(p => p.TollBooths)
                    .HasForeignKey(d => d.TollLocationId)
                    .HasConstraintName("FK_TollLocation_TollBooth");
            });

            modelBuilder.Entity<TollLocation>(entity =>
            {
                entity.ToTable("TollLocation");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TollPayment>(entity =>
            {
                entity.ToTable("TollPayment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TollPayments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Employee_TollPayment");
            });

            modelBuilder.Entity<TollPrice>(entity =>
            {
                entity.ToTable("TollPrice");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Vehicle)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.TollLocation)
                    .WithMany(p => p.TollPrices)
                    .HasForeignKey(d => d.TollLocationId)
                    .HasConstraintName("FK_TollLocation_TollPrice");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("Trip");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Vehicle)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Employee_Trip");

                entity.HasOne(d => d.EndCity)
                    .WithMany(p => p.TripEndCities)
                    .HasForeignKey(d => d.EndCityId)
                    .HasConstraintName("FK_TollLocation_Trip_End");

                entity.HasOne(d => d.StartCity)
                    .WithMany(p => p.TripStartCities)
                    .HasForeignKey(d => d.StartCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TollLocation_Trip_Start");
            });

            modelBuilder.Entity<TripPayment>(entity =>
            {
                entity.ToTable("TripPayment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripPayments)
                    .HasForeignKey(d => d.TripId)
                    .HasConstraintName("FK_Trip_TripPayment");
            });

            modelBuilder.Entity<TripPrice>(entity =>
            {
                entity.ToTable("TripPrice");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Vehicle)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.EndCity)
                    .WithMany(p => p.TripPriceEndCities)
                    .HasForeignKey(d => d.EndCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TollLocation_TravelPrice_End");

                entity.HasOne(d => d.StartCity)
                    .WithMany(p => p.TripPriceStartCities)
                    .HasForeignKey(d => d.StartCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TollLocation_TravelPrice_Start");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
