using Ecommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public class AppDbContext : IdentityDbContext <ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Supplier_Product>().HasKey(sp => new
            {
                sp.SupplierId,
                sp.ProductId
            });
            modelBuilder.Entity<Supplier_Product>().HasOne(p => p.Product).WithMany(sp => sp.Supplier_Products).HasForeignKey(p => p.ProductId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Supplier_Product>().HasOne(p => p.Supplier).WithMany(sp => sp.Supplier_Products).HasForeignKey(p => p.SupplierId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier_Product> Supplier_Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Brand> Brands { get; set; }


        //Orders Related Tables

        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
