using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.State.Authentificators
{
    public class Authentificator:IAuthentificator
    {
        private readonly IAuthentificationService _authentificationService;

        public Authentificator(IAuthentificationService authentificationService)
        {
            _authentificationService = authentificationService;
        }

        public Account CurrentAccount { get; private set; }
        public bool IsLoggedIn => CurrentAccount != null;
        public async Task<bool> Register(string username, string email, string password, string confirmPassword)
        {
            return await _authentificationService.Register(username, password, confirmPassword, email);
        }

        public async Task<Account> Login(string username, string password)
        {
            CurrentAccount = await _authentificationService.Login(username, password);
            return CurrentAccount;
        }

        public void Logout()
        {
            
        }
    }
}
