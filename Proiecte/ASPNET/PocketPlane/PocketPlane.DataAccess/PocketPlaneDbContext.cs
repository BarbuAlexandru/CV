using Microsoft.EntityFrameworkCore;
using PocketPlane.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketPlane.DataAccess
{
    public class PocketPlaneDbContext: DbContext
    {
        public PocketPlaneDbContext(DbContextOptions<PocketPlaneDbContext> options) : base(options)
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PlaneType> PlaneTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TicketHolder> TicketHolders { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightSchedule> FlightSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Flight>()
                .Property(u => u.BusinessPrice).HasColumnType("decimal(18,2)");

            builder.Entity<Flight>()
                .Property(u => u.EconomyPrice).HasColumnType("decimal(18,2)");
        }
    }
}
