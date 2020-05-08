using System;
using System.Collections.Generic;
using System.Text;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    public class AddProviderViewModelFactory:ICarPartViewModelFactory<AddProviderViewModel>
    {
        private readonly IProviderService _providerService;

        public AddProviderViewModelFactory(IProviderService providerService)
        {
            _providerService = providerService;
        }

        public AddProviderViewModel CreateViewModel()
        {
            return new AddProviderViewModel(_providerService);
        }
    }
}
