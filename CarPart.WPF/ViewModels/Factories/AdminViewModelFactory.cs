using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Navigators;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarPart.WPF.ViewModels.Factories
{
    public class AdminViewModelFactory:ICarPartViewModelFactory<AdminViewModel>
    {
        public AdminViewModel CreateViewModel()
        {
            return new AdminViewModel();
        }
    }
}
