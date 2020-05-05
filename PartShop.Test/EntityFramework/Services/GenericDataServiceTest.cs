using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework;
using PartShop.EntityFramework.Services;

namespace PartShop.Test.EntityFramework.Services
{
    [TestFixture]
    public class GenericDataServiceTest
    {
        [Test]
        public void InsertAccount()
        {
            IDataService<Account> accDataService = new GenericDataService<Account>(new CarPartDbContextFactory());

            accDataService.Create(new Account() { Username = "Denisario", Password = "1234", Email = "KRPTIK", UserRole = Role.ADMIN});
            Assert.AreEqual(accDataService.GetAll().Result.ToList().Count, 1);

        }
    }
}

