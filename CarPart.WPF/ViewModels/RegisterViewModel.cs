using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using CarPart.WPF.State.Authentificators;

namespace CarPart.WPF.ViewModels
{
    public class RegisterViewModel:ViewModelBase
    {
        public ICommand RegisterCommand { get; set; }

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

        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public RegisterViewModel(IAuthentificator authentificator)
        {
            RegisterCommand = new RegisterCommand(authentificator, this);
        }
    }
}
