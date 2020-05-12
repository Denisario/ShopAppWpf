using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    class PartViewModelFactory:ICarPartViewModelFactory<PartViewModel>
    {
        private readonly IPartService _partService;
        private readonly ICarService _carService;
        private readonly IProviderService _providerService;
        private readonly ICartService _cartService;
        private readonly IAuthentificator _authentificator;
        public PartViewModelFactory(IPartService partService, ICarService carService, IProviderService providerService, ICartService cartService, IAuthentificator authentificator)
        {
            _partService = partService;
            _carService = carService;
            _providerService = providerService;
            _cartService = cartService;
            _authentificator = authentificator;
        }

        public PartViewModel CreateViewModel()
        {
            return new PartViewModel(_partService, _carService, _providerService, _cartService, _authentificator);
        }
    }
}
