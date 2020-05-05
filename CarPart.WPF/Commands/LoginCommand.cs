﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.ViewModels;
using PartShop.Domain.Model;

namespace CarPart.WPF.Commands
{
    class LoginCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly IAuthentificator _authentificator;
        private readonly AuthViewModel _authViewModel;

        public LoginCommand(IAuthentificator authentificator, AuthViewModel authViewModel)
        {
            _authentificator = authentificator;
            _authViewModel = authViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Account account= await _authentificator.Login(_authViewModel.Username, parameter.ToString());
            MessageBox.Show(account.ToString());
        }

    }
}