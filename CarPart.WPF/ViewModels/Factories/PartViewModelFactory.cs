using System;
using System.Collections.Generic;
using System.Text;

namespace CarPart.WPF.ViewModels.Factories
{
    class PartViewModelFactory:ICarPartViewModelFactory<PartViewModel>
    {
        public PartViewModel CreateViewModel()
        {
            return new PartViewModel();
        }
    }
}
