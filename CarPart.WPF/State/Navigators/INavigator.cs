using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.ViewModels;

namespace CarPart.WPF.State.Navigators
{
    public enum ViewType
    {
        START,
        AUTH,
        REGISTER,
        HOME,
        PARTS,
        ADMIN,
        CART
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
