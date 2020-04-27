using PartShop.Domain.Model;
using System;
using System.Reflection.Metadata;
using PartShop.Domain.Services;
using PartShop.EntityFramework;
using PartShop.EntityFramework.Service;

namespace CarPart.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new CarPartDbContextFactory());
            //userService.Create(new User {Username = "FAD", Password = "123"}).Wait();
            Console.WriteLine(userService.Get(1).Result.Username);
            userService.Delete(1).Wait();
        }
    }
}
