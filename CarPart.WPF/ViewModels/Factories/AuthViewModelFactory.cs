using System;
using System.Collections.Generic;
using System.Text;

namespace CarPart.WPF.ViewModels.Factories
{
    public class AuthViewModelFactory:ICarPartViewModelFactory<AuthViewModel>
    {
        public AuthViewModel CreateViewModel()
        {
            return new AuthViewModel();
        }
    }
}
