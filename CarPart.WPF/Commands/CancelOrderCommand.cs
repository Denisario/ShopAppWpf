using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.ViewModels;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    class CancelOrderCommand:ICommand
    {
        private readonly IOrderService _orderService;
        private readonly IAuthentificator _authentificator;
        private readonly HomeViewModel _homeViewModel;
        public event EventHandler CanExecuteChanged;

        public CancelOrderCommand(IOrderService orderService, IAuthentificator authentificator, HomeViewModel homeViewModel)
        {
            _orderService = orderService;
            _authentificator = authentificator;
            _homeViewModel = homeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                await _orderService.CancelOrder(_authentificator.CurrentAccount, _homeViewModel.SelectedOrder);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
