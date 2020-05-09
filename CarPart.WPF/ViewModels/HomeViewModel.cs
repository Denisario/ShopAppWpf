using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Model;

namespace CarPart.WPF.ViewModels
{
    public class HomeViewModel:ViewModelBase
    {
        private IAuthentificator _authentificator;

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
        public HomeViewModel(IAuthentificator authentificator)
        {
            _authentificator = authentificator;
            //ДОБАВИТЬ ПРОВЕРКУ CURRENTACC и выводить MessgeBox и не пускать
            Username = _authentificator.CurrentAccount.Username;
            Email = _authentificator.CurrentAccount.Email;
            Balance = _authentificator.CurrentAccount.Balance;
            CreationTime = _authentificator.CurrentAccount.CreationTime;
            Orders = new ObservableCollection<Order>(_authentificator.CurrentAccount.Orders);
        }

    }
}
