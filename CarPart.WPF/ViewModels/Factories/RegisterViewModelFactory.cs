using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;

namespace CarPart.WPF.ViewModels.Factories
{
    public class RegisterViewModelFactory:ICarPartViewModelFactory<RegisterViewModel>
    {
        private readonly IAuthentificator _authentificator;

        public RegisterViewModelFactory(IAuthentificator authentificator)
        {
            _authentificator = authentificator;
        }

        public RegisterViewModel CreateViewModel()
        {
            return new RegisterViewModel(_authentificator);
        }
    }
}
