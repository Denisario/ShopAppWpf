using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.ViewModels.Factories;
using CarPart.WPF.Views;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class AddressViewModel : ViewModelBase
    {
        private string city;

        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string street;

        public string Street
        {
            get => street;
            set
            {
                street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        private int house;

        public int House
        {
            get => house;
            set
            {
                house = value;
                OnPropertyChanged(nameof(House));
            }
        }

        private int apartament;

        public int Apartament
        {
            get => apartament;
            set
            {
                apartament = value;
                OnPropertyChanged(nameof(Apartament));
            }
        }

        public ICommand CreateOrderCommand { get; set; }

        public AddressViewModel(IOrderService orderService, IAuthentificator authentificator, CartViewModel cartViewModel)
        {
            CreateOrderCommand = new CreateOrderCommand(orderService, authentificator, cartViewModel, this);
        }
    }
}