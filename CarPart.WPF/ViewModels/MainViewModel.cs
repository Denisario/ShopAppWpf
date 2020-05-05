using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using CarPart.WPF.State.Navigators;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarPart.WPF.ViewModels
{
    class MainViewModel:ViewModelBase
    {
        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;

            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.AUTH);

            CloseAppCommand=new CloseAppCommand();
        }

        public INavigator Navigator { get; set; }
        public ICommand CloseAppCommand { get; set; }
    }
}
