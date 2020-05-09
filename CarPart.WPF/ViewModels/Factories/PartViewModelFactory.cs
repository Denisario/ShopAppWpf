using System;
using System.Collections.Generic;
using System.Text;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    class PartViewModelFactory:ICarPartViewModelFactory<PartViewModel>
    {
        private readonly IPartService _partService;

        public PartViewModelFactory(IPartService partService)
        {
            _partService = partService;
        }

        public PartViewModel CreateViewModel()
        {
            return new PartViewModel(_partService);
        }
    }
}
