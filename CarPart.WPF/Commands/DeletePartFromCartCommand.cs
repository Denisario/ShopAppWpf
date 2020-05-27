using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.State;
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
        public event EventHandler CanExecuteChanged;

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
            try
            {
                await _cartService.DeletePartFromCart(PartCashInfo.PartCash, _authentificator.CurrentAccount);
                _cartViewModel.PartInCart.Remove(_cartViewModel.SelectedPart);
                //await App.service.GetRequiredService<CartViewModel>().GetAllPartsInCart();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
