using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PartShop.Domain.Model;
using PartShop.Domain.Services.Impl;
using PartShop.EntityFramework;
using PartShop.EntityFramework.Service;

namespace PartShop.Domain.Test.Services.Impl
{
    [TestFixture]
    public class AuthServiceTest
    {
        [Test]
        public async Task Register_WithTrueResults_ReturnsTrueResult()
        {
            AuthService authService=new AuthService(
                new GenericDataService<Role>(new CarPartDbContextFactory()),
                new GenericDataService<User>(new CarPartDbContextFactory())
            );

            bool account = authService.Register("dsadsaas", "fdsfl", "fdsfl", "das").Result;

            Console.WriteLine(account);
            Assert.AreEqual(account, true);

        }
    }
}
