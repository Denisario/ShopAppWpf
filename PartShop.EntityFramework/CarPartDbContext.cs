using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PartShop.Domain.Model;

namespace PartShop.EntityFramework
{
    public class CarPartDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CarPart> CarParts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartOrder> PartOrders { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Address> Address { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CarPartShopDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(t => new {t.RoleId, t.UserId});

            modelBuilder.Entity<UserRole>()
                .HasOne(u => u.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ui => ui.UserId);
            
            modelBuilder.Entity<UserRole>()
                .HasOne(r => r.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ri => ri.RoleId);

            modelBuilder.Entity<CarPart>()
                .HasKey(t => new { t.CarId, t.PartId });

            modelBuilder.Entity<CarPart>()
                .HasOne(u => u.Car)
                .WithMany(ur => ur.CarParts)
                .HasForeignKey(ui => ui.CarId);

            modelBuilder.Entity<CarPart>()
                .HasOne(r => r.Part)
                .WithMany(ur => ur.CarParts)
                .HasForeignKey(ri => ri.PartId);

            modelBuilder.Entity<PartOrder>()
                .HasKey(t => new { t.PartId, t.OrderId });

            modelBuilder.Entity<PartOrder>()
                .HasOne(u => u.Part)
                .WithMany(ur => ur.PartOrders)
                .HasForeignKey(ui => ui.PartId);

            modelBuilder.Entity<PartOrder>()
                .HasOne(r => r.Order)
                .WithMany(ur => ur.PartOrders)
                .HasForeignKey(ri => ri.OrderId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Account)
                .WithOne(b => b.User)
                .HasForeignKey<Account>(c => c.Id);

            modelBuilder.Entity<Order>()
                .HasOne(a => a.Address)
                .WithOne(b => b.Order)
                .HasForeignKey<Address>(c => c.Id);
        }
    }
}
