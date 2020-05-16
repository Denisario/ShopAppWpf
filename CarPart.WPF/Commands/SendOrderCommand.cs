using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    public class SendOrderCommand:ICommand
    {
        private readonly IOrderService _orderService;
        private readonly OrderViewModel _orderViewModel;
        public SendOrderCommand(IOrderService orderService, OrderViewModel orderViewModel)
        {
            _orderService = orderService;
            _orderViewModel = orderViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await _orderService.DelivOrder(_orderViewModel.SelectedOrder);
        }

        public event EventHandler CanExecuteChanged;
    }
}
