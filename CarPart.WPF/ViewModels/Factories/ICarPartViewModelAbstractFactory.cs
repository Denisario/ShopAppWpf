using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Navigators;

namespace CarPart.WPF.ViewModels.Factories
{
    public interface ICarPartViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
