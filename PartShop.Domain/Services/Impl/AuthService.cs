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
        private readonly IDataService<Account> _accountService;
        private readonly IDataService<User> _userService;
        private readonly IDataService<UserRole> _userRoleService;


        public AuthService(IDataService<Role> roleService, IDataService<UserRole> userRoleService, IDataService<User> userService, IDataService<Account> accountService)
        {
            _roleService = roleService;
            _userRoleService = userRoleService;
            _userService = userService;
            _accountService = accountService;
        }

        public async Task<bool> Register(string username, string password, string confirmPass, string email)
        {
            Role role = _roleService.Get(1).Result;
            bool success = false;
            if (password == confirmPass)
            {

                User user = new User()
                {
                    Username = username,
                    Password = HashPass(password),
                    Email = email,
                    
                };
                Account account = new Account()
                {
                    User = user,
                    CreationDate = DateTime.Now
                };

                UserRole userRole=new UserRole();
                userRole.Role = role;
                userRole.User = user;

                user.Account = account;

                await _userService.Create(user);
                await _accountService.Create(account);
                await _userRoleService.Create(userRole);
                success = true;
            }

            return success;
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
