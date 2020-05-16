using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.ViewModels;
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
            _cartViewModel = cartViewModel;
            _addressViewModel = addressViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            
            _orderService.CreateOrder(_authentificator.CurrentAccount,
                new List<PartFullInfo>(_cartViewModel.PartInCart.Where(x => x.IsSelected == true)), new Address()
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
