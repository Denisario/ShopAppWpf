using System;
using System.Collections.Generic;
using System.Text;

namespace CarPart.WPF.ViewModels.Factories
{
    public class RegisterViewModelFactory:ICarPartViewModelFactory<RegisterViewModel>
    {
        public RegisterViewModel CreateViewModel()
        {
            return new RegisterViewModel();
        }
    }
}
