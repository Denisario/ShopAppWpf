using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    public class FinishOrderCommand:ICommand
    {
        private readonly IOrderService _orderService;
        private readonly HomeViewModel _homeViewModel;

        public FinishOrderCommand(HomeViewModel homeViewModel, IOrderService orderService)
        {
            _homeViewModel = homeViewModel;
            _orderService = orderService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
             await _orderService.FinishOrder(_homeViewModel.SelectedOrder);
        }

        public event EventHandler CanExecuteChanged;
    }
}
