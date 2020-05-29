using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.State.Navigators;

namespace CarPart.WPF.ViewModels
{
    public class AdminViewModel:ViewModelBase
    {
        public ICommand LogoutCommand { get; set; }

        public AdminViewModel(IAuthentificator authentificator)
        {
            LogoutCommand=new LogoutCommand(authentificator);
        }
    }
}
