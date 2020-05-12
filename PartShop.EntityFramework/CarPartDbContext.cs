using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PartShop.Domain.Model;

namespace PartShop.EntityFramework
{
    public class CarPartDbContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CarPart> CarParts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<OrderParts> OrderParts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PartProvider> PartProviders { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public CarPartDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    modelBuilder.Entity<UserRole>()
        //        .HasKey(t => new {t.RoleId, t.UserId});


        modelBuilder.Entity<CarPart>().HasKey(t => new {t.PartId, t.CarId});
        modelBuilder.Entity<OrderParts>().HasKey(t => new {t.PartId, t.OrderId});
        modelBuilder.Entity<PartProvider>().HasKey(t => new {t.PartId, t.ProviderId});


        modelBuilder.Entity<CarPart>()
                    .HasOne(u => u.Car)
                    .WithMany(ur => ur.CarParts)
                    .HasForeignKey(ui => ui.CarId);

        modelBuilder.Entity<CarPart>()
                    .HasOne(r => r.Part)
                    .WithMany(ur => ur.CarParts)
                    .HasForeignKey(ri => ri.PartId);


            modelBuilder.Entity<OrderParts>()
                .HasOne(u => u.Order)
                .WithMany(ur => ur.Parts)
                .HasForeignKey(ui => ui.PartId);

            modelBuilder.Entity<OrderParts>()
                .HasOne(r => r.Order)
                .WithMany(ur => ur.Parts)
                .HasForeignKey(ri => ri.OrderId);

            modelBuilder.Entity<PartProvider>()
                .HasOne(r => r.Provider)
                .WithMany(u => u.PartProviders)
                .HasForeignKey(e => e.ProviderId);
            
            modelBuilder.Entity<PartProvider>()
                .HasOne(r => r.Part)
                .WithMany(u => u.PartProviders)
                .HasForeignKey(e => e.PartId);
            modelBuilder.Entity<Account>().HasMany(c => c.Carts).WithOne(c => c.Account);

            modelBuilder.Entity<Cart>().HasOne(a => a.Account).WithMany(a => a.Carts).HasForeignKey(s => s.AccountId);

            modelBuilder.Entity<Address>().Property(a => a.Id).ValueGeneratedNever();
            //modelBuilder.Entity<Account>().Property(a => a.Id).ValueGeneratedNever();
            modelBuilder.Entity<PartProvider>().Property(a => a.PartId).ValueGeneratedNever();
            modelBuilder.Entity<PartProvider>().Property(a => a.ProviderId).ValueGeneratedNever();

            modelBuilder.Entity<CarPart>().Property(a => a.PartId).ValueGeneratedNever();
            modelBuilder.Entity<CarPart>().Property(a => a.CarId).ValueGeneratedNever();
        }
    }
}
