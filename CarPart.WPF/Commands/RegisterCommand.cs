﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.State.Navigators;
using CarPart.WPF.ViewModels;
using CarPart.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CarPart.WPF.Commands
{
    public class RegisterCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly IAuthentificator _authentificator;
        private readonly RegisterViewModel _registerViewModel;
        

        public RegisterCommand(IAuthentificator authentificator, RegisterViewModel registerViewModel)
        {
            _authentificator = authentificator;
            _registerViewModel = registerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var nav = App.service.GetRequiredService<INavigator>();
            var vmFactory = App.service.GetRequiredService<ICarPartViewModelAbstractFactory>();

            var values = (object[]) parameter;
            bool success = await _authentificator.Register(_registerViewModel.Username,
                                                           _registerViewModel.Email,
                                                           (values[0] as PasswordBox)?.Password,
                                              (values[1] as PasswordBox)?.Password);

            if(success) nav.CurrentViewModel = vmFactory.CreateViewModel(ViewType.AUTH);
        }

        
    }
}
