using System;
using System.Collections.Generic;
using System.Text;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    public class AddCarViewModelFactory : ICarPartViewModelFactory<AddCarViewModel>
    {
        private readonly ICarService _carService;

        public AddCarViewModelFactory(ICarService carService)
        {
            _carService = carService;
        }

        public AddCarViewModel CreateViewModel()
        {
            return new AddCarViewModel(_carService);
        }
    }
}
