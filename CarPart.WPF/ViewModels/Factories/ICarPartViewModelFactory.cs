using System;
using System.Collections.Generic;
using System.Text;

namespace CarPart.WPF.ViewModels.Factories
{
    public interface ICarPartViewModelFactory<T> where T:ViewModelBase
    {
        T CreateViewModel();
    }
}
