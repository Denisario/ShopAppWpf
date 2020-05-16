using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class OrderViewModel:ViewModelBase
    {
        private readonly IOrderService _orderService;


        private ObservableCollection<Order> orders;

        public OrderViewModel(IOrderService orderService)
        {
            _orderService = orderService;
            ShowDetailsCommand = new GetCheckCommand(_orderService, this);
            SendOrderCommand=new SendOrderCommand(_orderService, this);
            GetAllOrders();
        }

        public ObservableCollection<Order> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private Order selectedOrder;

        public Order SelectedOrder
        {
            get => selectedOrder;
            set
            {
                selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public ICommand ShowDetailsCommand { get; set; }
        public ICommand SendOrderCommand { get; set; }

        private async void GetAllOrders()
        {
            Orders = new ObservableCollection<Order>(await _orderService.GetAll());
        }
    }
}
