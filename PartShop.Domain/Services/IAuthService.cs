using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface IAuthService
    {
        public Task<bool> Register(string username, string password, string confirmPass, string email);
        public Task<Account> Login(string username, string password);
    }
}
