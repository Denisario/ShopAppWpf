using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;

namespace CarPart.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory:ICarPartViewModelFactory<HomeViewModel>
    {
        private readonly IAuthentificator _authentificator;

        public HomeViewModelFactory(IAuthentificator authentificator)
        {
            _authentificator = authentificator;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_authentificator);
        }
    }
}
