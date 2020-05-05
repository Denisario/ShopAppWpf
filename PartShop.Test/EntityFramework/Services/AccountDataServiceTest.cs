using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework;
using PartShop.EntityFramework.Services;

namespace PartShop.Test.EntityFramework.Services
{
    [TestFixture]
    public class AccountDataServiceTest
    {
        [Test]
        public void CreateAccount_InsertNewUser_ReturnTotalUsers()
        {
            IDataService<Account> accountDataService=new AccountDataService(new CarPartDbContextFactory());

            accountDataService.Create(new Account()
            {
                Username = "Denisario", Password = "1234", Email = "KRPTIK", UserRole = Role.ADMIN,
                CreationTime = DateTime.Now,
                Orders = new List<Order>()
                {
                    new Order()
                    {
                        OrderCreationTime = DateTime.Now,
                        Status = OrderStatus.CREATED
                    }
                }
            });

            Assert.AreEqual(accountDataService.GetAll().Result.ToList().Count, 3);
        }
        
        //!!work!!!CHECK COMMENT!!!
        [Test]
        public void UpdateAccountTest_UpdateUserById_ShowResultInDatabase()
        {
            IDataService<Account> accountDataService = new AccountDataService(new CarPartDbContextFactory());

            accountDataService.Update(1,new Account()
            {
                Username = "Denisar31o",
                Password = "1234",
                Email = "KR0TIK",
                UserRole = Role.ADMIN,
                CreationTime = DateTime.Now,
                //ДОБАВЛЯЕТ ТАК НОВУЮ ЗАПИСЬ
                Orders = new List<Order>()
                {
                    new Order()
                    {
                        OrderCreationTime = DateTime.Now,
                        Status = OrderStatus.FINISHED
                    }
                }
            });

            Assert.AreEqual(accountDataService.Get(1).Result.Username, "Denisar31o");
        }
        [Test]
        public void DeleteUserTest_DeleteUserById_ShowResultInDataBase()
        {
            IDataService<Account> accountDataService = new AccountDataService(new CarPartDbContextFactory());

            bool resultTask = accountDataService.Delete(1).Result;

            Assert.AreEqual(resultTask, false);
        }

        [Test]
        public async Task GetUserByUsername()
        {
            IAccountService accountService=new AccountDataService(new CarPartDbContextFactory());

            Account account =await accountService.GetAccountByUsername("1");

            Assert.AreEqual(account.Username, "1");
        }
    }
}
