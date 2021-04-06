using DrumetiiShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrumetiiShop
{
    public class DrumetiiShopDbContext : DbContext
    {
        public DrumetiiShopDbContext(DbContextOptions<DrumetiiShopDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProductConnection> CartProductConnections { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
