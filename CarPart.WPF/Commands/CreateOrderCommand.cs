using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.ViewModels;
using CarPart.WPF.ViewModels.Factories;
using CarPart.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    class CreateOrderCommand:ICommand
    {
        private readonly IOrderService _orderService;
        private readonly IAuthentificator _authentificator;
        private readonly CartViewModel _cartViewModel;
        private readonly AddressViewModel _addressViewModel;
        public CreateOrderCommand(IOrderService orderService, IAuthentificator authentificator, CartViewModel cartViewModel,AddressViewModel addressViewModel)
        {
            _orderService = orderService;
            _authentificator = authentificator;
            _cartViewModel = App.service.GetRequiredService<ICarPartViewModelFactory<CartViewModel>>().CreateViewModel();
            _addressViewModel = addressViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {


            _orderService.CreateOrder(_authentificator.CurrentAccount,
               _authentificator.Parts.Where(x => x.IsSelected).ToList(), new Address()
                {
                    Apartament = _addressViewModel.Apartament,
                    City = _addressViewModel.City,
                    House = _addressViewModel.House,
                    Street = _addressViewModel.Street
                });
        }
        public event EventHandler CanExecuteChanged;
    }
}
