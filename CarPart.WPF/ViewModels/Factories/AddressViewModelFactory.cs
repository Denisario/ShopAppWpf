using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    class AddressViewModelFactory : ICarPartViewModelFactory<AddressViewModel>
    {
        private readonly IOrderService _orderService;
        private readonly IAuthentificator _authentificator;

        public AddressViewModelFactory(IAuthentificator authentificator, IOrderService orderService)
        {
            _authentificator = authentificator;
            _orderService = orderService;
        }

        public AddressViewModel CreateViewModel()
        {
            return new AddressViewModel(_orderService, _authentificator);
        }
    }
}