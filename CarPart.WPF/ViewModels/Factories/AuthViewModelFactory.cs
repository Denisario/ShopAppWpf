using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;

namespace CarPart.WPF.ViewModels.Factories
{
    public class AuthViewModelFactory:ICarPartViewModelFactory<AuthViewModel>
    {
        private readonly IAuthentificator _authentificator;

        public AuthViewModelFactory(IAuthentificator authentificator)
        {
            _authentificator = authentificator;
        }

        public AuthViewModel CreateViewModel()
        {
            return new AuthViewModel(_authentificator);
        }
    }
}
