using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface IAuthentificationService
    {
        Task<bool> Register(string username, string password, string confirmPassword, string email);
        Task<Account> Login(string username, string password);
    }
}
