using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.ViewModels;
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
            await _cartService.AddPartToCart(_partViewModel.Part, _authentificator.CurrentAccount, 0);
        }

        public event EventHandler CanExecuteChanged;
    }
}
