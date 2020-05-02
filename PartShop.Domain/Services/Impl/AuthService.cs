using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IDataService<Role> _roleService;
        //private readonly IDataService<Account> _accountService;
        private readonly IDataService<User> _userService;


        public AuthService(IDataService<Role> roleService, IDataService<User> userService)
        {
            _roleService = roleService;
            _userService = userService;
            //_accountService = accountService;
        }

        public async Task<bool> Register(string username, string password, string confirmPass, string email)
        {
           await _userService.Create(new User()
            {
                Username = username,
                Password = password,
                Account = new Account()
            });

           return true;
        }

        public async Task<Account> Login(string username, string password)
        {
            throw new NotImplementedException();
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
