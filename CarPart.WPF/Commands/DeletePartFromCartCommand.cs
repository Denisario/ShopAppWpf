using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    public class DeletePartFromCartCommand:ICommand
    {
        private readonly CartViewModel _cartViewModel;
        private readonly ICartService _cartService;
        private readonly IAuthentificator _authentificator;

        public DeletePartFromCartCommand(CartViewModel cartViewModel, ICartService cartService, IAuthentificator authentificator)
        {
            _cartViewModel = cartViewModel;
            _cartService = cartService;
            _authentificator = authentificator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            //if selected part is null

            Cart cart=await _cartService.DeletePartFromCart(_cartViewModel.SelectedPart, _authentificator.CurrentAccount);

            _cartViewModel.PartInCart.Remove(_cartViewModel.SelectedPart);
            App.service.GetRequiredService<CartViewModel>().GetAllPartsInCart();
        }

        public event EventHandler CanExecuteChanged;
    }
}
