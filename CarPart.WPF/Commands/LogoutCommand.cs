using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.State.Navigators;
using CarPart.WPF.ViewModels;
using CarPart.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CarPart.WPF.Commands
{
    public class LogoutCommand:ICommand
    {
        private readonly IAuthentificator _authentificator;
        public event EventHandler CanExecuteChanged;

        public LogoutCommand(IAuthentificator authentificator)
        {
            _authentificator = authentificator;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var nav = App.service.GetRequiredService<INavigator>();
            var vmFactory = App.service.GetRequiredService<ICarPartViewModelAbstractFactory>();
            _authentificator.Logout();

            nav.CurrentViewModel = vmFactory.CreateViewModel(ViewType.AUTH);
        }
    }
}
