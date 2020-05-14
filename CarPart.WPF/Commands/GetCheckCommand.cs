using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    public class GetCheckCommand:ICommand
    {
        private readonly IOrderService _orderService;
        private readonly HomeViewModel _homeViewModel;
        public GetCheckCommand(IOrderService orderService, HomeViewModel homeViewModel)
        {
            _orderService = orderService;
            _homeViewModel = homeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await _orderService.PrintCheck(_homeViewModel.SelectedOrder.Id);
        }

        public event EventHandler CanExecuteChanged;
    }
}
