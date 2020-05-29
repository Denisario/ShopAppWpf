using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.State.Navigators;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarPart.WPF.ViewModels.Factories
{
    public class AdminViewModelFactory:ICarPartViewModelFactory<AdminViewModel>
    {
        private readonly IAuthentificator _authentificator;

        public AdminViewModelFactory(IAuthentificator authentificator)
        {
            _authentificator = authentificator;
        }

        public AdminViewModel CreateViewModel()
        {
            return new AdminViewModel(_authentificator);
        }
    }
}
