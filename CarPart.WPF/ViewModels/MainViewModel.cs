using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using CarPart.WPF.State.Navigators;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarPart.WPF.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public ICommand CloseAppCommand { get; set; }
        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.AUTH);
            CloseAppCommand=new CloseAppCommand();
        }

    }
}
