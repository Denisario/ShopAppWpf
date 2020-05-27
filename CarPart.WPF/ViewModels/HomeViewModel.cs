using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class HomeViewModel:ViewModelBase
    {
        private IAuthentificator _authentificator;

        public ICommand GetCheckCommand { get; set; }
        public ICommand CancelOrderCommand { get; set; }
        public ICommand FinishOrderCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        private string username;
        public string Username {
            get=>username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(email));
            }
        }

        private double balance;
        public double Balance
        {
            get => balance;
            set
            {
                balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        private DateTime creationTime;
        public DateTime CreationTime
        {
            get => creationTime;
            set
            {
                creationTime = value;
                OnPropertyChanged(nameof(CreationTime));
            }
        }

        private ObservableCollection<Order> orders;

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
        public HomeViewModel(IAuthentificator authentificator, IOrderService orderService)
        {
            _authentificator = authentificator;
            LogoutCommand = new LogoutCommand(authentificator);
            Username = _authentificator.CurrentAccount.Username;
            Email = _authentificator.CurrentAccount.Email;
            Balance = _authentificator.CurrentAccount.Balance;
            CreationTime = _authentificator.CurrentAccount.CreationTime;
            Orders = new ObservableCollection<Order>(_authentificator.CurrentAccount.Orders);
            GetCheckCommand =new GetCheckCommand(orderService,this);
            CancelOrderCommand=new CancelOrderCommand(orderService, authentificator, this);
            FinishOrderCommand=new FinishOrderCommand(this, orderService);

        }
    }
}
