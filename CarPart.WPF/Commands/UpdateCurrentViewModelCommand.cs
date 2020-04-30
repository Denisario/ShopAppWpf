using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.State.Navigators;
using CarPart.WPF.ViewModels;

namespace CarPart.WPF.Commands
{
    public class UpdateCurrentViewModelCommand:ICommand 
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType) parameter;
                switch (viewType)
                {
                    case ViewType.AUTH:
                        _navigator.CurrentViewModel=new AuthViewModel();
                        break;
                    case ViewType.REGISTER:
                        _navigator.CurrentViewModel=new RegisterViewModel();
                        break;
                    default:
                        break;
                }
            }
        }


    }
}
