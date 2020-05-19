using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.State.Navigators;
using CarPart.WPF.ViewModels;
using CarPart.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    public class AddPartToCartCommand:ICommand
    {
        private readonly PartViewModel _partViewModel;
        private readonly ICartService _cartService;
        private readonly IAuthentificator _authentificator;

        public AddPartToCartCommand(PartViewModel partViewModel, ICartService cartService, IAuthentificator authentificator)
        {
            _partViewModel = partViewModel;
            _cartService = cartService;
            _authentificator = authentificator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var nav = App.service.GetRequiredService<INavigator>();
            var vmFactory = App.service.GetRequiredService<ICarPartViewModelAbstractFactory>();

            if (_authentificator.IsLoggedIn == false)
            {
                nav.CurrentViewModel = vmFactory.CreateViewModel(ViewType.AUTH);
                return;
            }

            if (_partViewModel.Part == null) MessageBox.Show("You don't select the part");
            else await _cartService.AddPartToCart(_partViewModel.Part, _authentificator.CurrentAccount, 1);
        }

        public event EventHandler CanExecuteChanged;
    }
}
