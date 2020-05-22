using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace CarPart.WPF.State.Authentificators
{
    public interface IAuthentificator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }
        Task<bool> Register(string username, string email, string password, string confirmPassword);

        Task<Account> Login(string username, string password);

        void Logout();
    }
}
