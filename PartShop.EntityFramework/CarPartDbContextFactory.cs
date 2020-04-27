using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PartShop.EntityFramework
{
    public class CarPartDbContextFactory:IDesignTimeDbContextFactory<CarPartDbContext>
    {
        public CarPartDbContext CreateDbContext(string[] args)
        {
            var options=new DbContextOptionsBuilder<CarPartDbContext>();
            options.UseSqlServer("Server=.\\SQLEXPRESS;Database=CarPartShopDB;Trusted_Connection=True;");
            return new CarPartDbContext(options.Options);
        }
    }
}
