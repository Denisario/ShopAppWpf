using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using CarPart.WPF.State.Authentificators;

namespace CarPart.WPF.ViewModels
{
    public class AuthViewModel:ViewModelBase
    {
        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public ICommand LoginCommand { get; set; }

        public AuthViewModel(IAuthentificator authentificator)
        {
            LoginCommand=new LoginCommand(authentificator, this);
        }
    }
}
