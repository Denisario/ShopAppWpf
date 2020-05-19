using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            Parts=new List<PartFullInfo>();
        }

        public Account CurrentAccount { get; private set; }
        public bool IsLoggedIn => CurrentAccount != null;
        public async Task<bool> Register(string username, string email, string password, string confirmPassword)
        {
            try
            {
               await _authentificationService.Register(username, password, confirmPassword, email);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }

        public async Task<Account> Login(string username, string password)
        {
            try
            {
                CurrentAccount = await _authentificationService.Login(username, password);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return CurrentAccount;
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public List<PartFullInfo> Parts { get; set; }
    }
}
