using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            username = username.ToLower();
            Account account = await _accountService.GetAccountByUsername(username);
            if (account != null)
            {
                throw new Exception("Данный пользователь зарегистирован");
            }

            email = email.ToLower();

            if (password!=confirmPassword) throw new Exception("Пароли не совпадают");


            if((password.Length<=8)&&(password.Length>=15)) throw new Exception("Длина пароля должна быть не менее 8 и не более 15 символов");

            Account newAccount = new Account()
               {
                   Username = username.ToLower(),
                   Password = HashPass(password),
                   CreationTime = DateTime.Now,
                   Email = email,
                   UserRole = Role.USER
               };

            if (newAccount.Id == 1) newAccount.UserRole = Role.ADMIN;

            var results = new List<ValidationResult>();
            var context=new ValidationContext(newAccount);

            StringBuilder errorResult=new StringBuilder();

            if (!Validator.TryValidateObject(newAccount,context, results, true))
            {
                foreach (var error in results)
                {
                    errorResult.Append(error.ErrorMessage+'\n');
                }
                throw new Exception(errorResult.ToString());
            }
            else
            {
                await _accountService.Create(newAccount);
            }

              return true;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account account = await _accountService.GetAccountByUsername(username);
            if (account==null) throw new Exception("User not found");
            if (account.Password != HashPass(password))
            {
                throw new Exception("Incorrect password");
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
