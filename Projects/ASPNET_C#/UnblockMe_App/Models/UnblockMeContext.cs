using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UnblockMe_App.Models
{
    public partial class UnblockMeContext : IdentityDbContext<User>
    {
        public UnblockMeContext()
        {
        }

        public UnblockMeContext(DbContextOptions<UnblockMeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRating> UserRating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.LicencePlate)
                    .HasName("PK__Car__6570E330ED6D2E65");

                entity.Property(e => e.LicencePlate)
                    .HasColumnName("LicencePlate")
                    .HasMaxLength(20);

                entity.Property(e => e.AdditionalInfo)
                    .HasColumnName("AdditionalInfo")
                    .HasMaxLength(100);

                entity.Property(e => e.BlockedByLicencePlate)
                    .HasColumnName("BlockedByLicencePlate")
                    .HasMaxLength(20);

                entity.Property(e => e.BlockedLicencePlate)
                    .HasColumnName("BlockedLicencePlate")
                    .HasMaxLength(20);

                entity.Property(e => e.Color)
                    .HasColumnName("Color")
                    .HasMaxLength(20);

                entity.Property(e => e.Maker)
                    .HasColumnName("Maker")
                    .HasMaxLength(20);

                entity.Property(e => e.Model)
                    .HasColumnName("Model")
                    .HasMaxLength(20);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerId");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Car__owner_id__2A4B4B5E");
            });



            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AdditionalInfo)
                    .HasColumnName("AdditionalInfo")
                    .HasMaxLength(100);

                entity.Property(e => e.AverageRating)
                .HasColumnName("AverageRating");

                entity.Property(e => e.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(20);
            });



            modelBuilder.Entity<UserRating>(entity =>
            {
                entity.ToTable("UserRating");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Rating).HasColumnName("Rating");

                entity.Property(e => e.Comment).HasColumnName("Comment");

                entity.Property(e => e.UserRatedId).HasColumnName("UserRatedId");

                entity.Property(e => e.UserRatingId).HasColumnName("UserRatingId");

                entity.HasOne(d => d.UserRated)
                    .WithMany(p => p.UserRatingUserRated)
                    .HasForeignKey(d => d.UserRatedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Rati__user___267ABA7A");

                entity.HasOne(d => d.UserRatingNavigation)
                    .WithMany(p => p.UserRatingUserRatingNavigation)
                    .HasForeignKey(d => d.UserRatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Rati__user___276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
