using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework;
using PartShop.EntityFramework.Services;

namespace PartShop.Test.Domain.Service
{
    [TestFixture]
    public class AuthentificationServiceTest
    {
        private IAuthentificationService _authentificationService;

        [SetUp]
        public void SetUp()
        {
            _authentificationService=new AuthentificationService(new AccountDataService(new CarPartDbContextFactory()));
        }

        [Test]
        public async Task Register_WithTrueResults_ReturnsTrueResult()
        {
            string username = "desa";
            string password = "123";
            string email = "dsadasdasda";

            bool result = await _authentificationService.Register("1", "1", "1", "1");

            Assert.AreEqual(result, true);
        }

        [Test]
        public async Task Login_WithTrueResults_ReturnsAccount()
        {
            string username = "desa";
            string password = "123";
            string email = "dsadasdasda";

            Account result = await _authentificationService.Login("1", "1");

            Assert.AreEqual(result.Username, "1");
        }

        [Test]
        public async Task Login_WithNonEqualPassword_ReturnsIncorrectPasswordException()
        {
            Assert.ThrowsAsync<IncorrectPasswordException>(()=> _authentificationService.Login("1", "12"));
        }

        [Test]
        public async Task Login_WithNonExistsLogin_ReturnsIncorrectPasswordException()
        {
            Assert.ThrowsAsync<UserNotFoundException>(() => _authentificationService.Login("1213", "12"));
        }

        [Test]
        public async Task Register_WithNonEqualPassword_ReturnsIncorrectPasswordException()
        {
            Assert.ThrowsAsync<IncorrectPasswordException>(() => _authentificationService.Register("1dsadas", "12", "123", "dasd"));
        }

        [Test]
        public async Task Register_WithAlreadyExistsLogin_ReturnsUserHasBeenAlreadyRegisteredException()
        {
            Assert.ThrowsAsync<UserHasBeenAlreadyRegisteredException>(() => _authentificationService.Register("1", "12", "12", "dasd"));
        }
    }
}
