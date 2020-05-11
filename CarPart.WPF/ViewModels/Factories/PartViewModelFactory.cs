using System;
using System.Collections.Generic;
using System.Text;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    class PartViewModelFactory:ICarPartViewModelFactory<PartViewModel>
    {
        private readonly IPartService _partService;
        private readonly ICarService _carService;
        private readonly IProviderService _providerService;

        public PartViewModelFactory(IPartService partService, ICarService carService, IProviderService providerService)
        {
            _partService = partService;
            _carService = carService;
            _providerService = providerService;
        }

        public PartViewModel CreateViewModel()
        {
            return new PartViewModel(_partService, _carService, _providerService);
        }
    }
}
