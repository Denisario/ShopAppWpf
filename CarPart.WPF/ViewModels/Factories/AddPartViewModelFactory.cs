using System;
using System.Collections.Generic;
using System.Text;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    public class AddPartViewModelFactory:ICarPartViewModelFactory<AddPartViewModel>
    {
        private readonly IProviderService _providerService;
        private readonly ICarService _carService;
        private readonly IPartService _partService;

        public AddPartViewModelFactory(IProviderService providerService, ICarService carService, IPartService partService)
        {
            _providerService = providerService;
            _carService = carService;
            _partService = partService;
        }

        public AddPartViewModel CreateViewModel()
        {
            return new AddPartViewModel(_providerService, _carService, _partService);
        }
    }
}
