using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    class AddressViewModelFactory:ICarPartViewModelFactory<AddressViewModel>
    {
        private readonly IOrderService _orderService;
        private readonly IAuthentificator _authentificator;
        private readonly CartViewModel _cartViewModel;

        public AddressViewModelFactory(IAuthentificator authentificator, IOrderService orderService, CartViewModel cartViewModel)
        {
            _authentificator = authentificator;
            _orderService = orderService;
            _cartViewModel = cartViewModel;
        }

        public AddressViewModel CreateViewModel()
        {
            return new AddressViewModel(_orderService, _authentificator, _cartViewModel);
        }
    }
}
