﻿using Microsoft.EntityFrameworkCore;
using System;
using static System.Net.Mime.MediaTypeNames;
using TechXpress.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TechXpress_DAL.Models;

namespace TechXpress.Context
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

      
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Review> Reviews { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>()
        //        .HasMany(c => c.Products)
        //        .WithOne(p => p.Category)
        //        .HasForeignKey(p => p.CategoryId);

        //    modelBuilder.Entity<Brand>()
        //        .HasMany(b => b.Products)
        //        .WithOne(p => p.Brands)
        //        .HasForeignKey(p => p.BrandId);

        //    modelBuilder.Entity<ProductColor>()
        //        .HasKey(pc => new { pc.ProductId, pc.ColorId });

        //    modelBuilder.Entity<ProductColor>()
        //        .HasOne(pc => pc.Product)
        //        .WithMany(p => p.ProductColors)
        //        .HasForeignKey(pc => pc.ProductId);

        //    modelBuilder.Entity<ProductColor>()
        //        .HasOne(pc => pc.Color)
        //        .WithMany(c => c.productColors)
        //        .HasForeignKey(pc => pc.ColorId);

        //    modelBuilder.Entity<Order>()
        //        .HasOne(O => O.User)
        //        .WithMany(U => U.Orders)
        //        .HasForeignKey(O => O.UserId);




        //    modelBuilder.Entity<OrderItem>()
        //       .HasKey(oi => new { oi.OrderId, oi.ProductId });

        //    modelBuilder.Entity<OrderItem>()
        //        .HasOne(oi => oi.Order)
        //        .WithMany(o => o.OrderItems);

        //    modelBuilder.Entity<OrderItem>()
        //        .HasOne(oi => oi.Product)
        //        .WithMany(p => p.OrderItems);


        //}
    }
}
