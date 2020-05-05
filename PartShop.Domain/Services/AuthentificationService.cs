using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Exceptions;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public class AuthentificationService:IAuthentificationService
    {
        private readonly IAccountService _accountService;

        public AuthentificationService(IAccountService accountService)
        {
            _accountService = accountService;
        }


        public async Task<bool> Register(string username, string password, string confirmPassword, string email)
        {
            //REWORK

            if (_accountService.GetAccountByUsername(username).Result != null)
            {
                throw new UserHasBeenAlreadyRegisteredException("User has been already registered");
            }

            if (password!=confirmPassword) throw new IncorrectPasswordException("Passwords are not equal");

               Account account = new Account()
               {
                   Username = username,
                   Password = HashPass(password),
                   CreationTime = DateTime.Now,
                   Email = email,
                   UserRole = Role.USER
               };

              await _accountService.Create(account);
              return true;
        }

        public async Task<Account> Login(string username, string password)
        {
            if(_accountService.GetAccountByUsername(username).Result==null) throw new UserNotFoundException("User not found");
            Account account = await _accountService.GetAccountByUsername(username);
            if (account.Password != HashPass(password))
            {
                throw new IncorrectPasswordException("Incorrect password");
            }

            return account;
        }

        private string HashPass(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
