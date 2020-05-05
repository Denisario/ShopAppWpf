using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Navigators;

namespace CarPart.WPF.ViewModels.Factories
{
    public class CarPartViewModelAbstractFactory:ICarPartViewModelAbstractFactory
    {
        private readonly ICarPartViewModelFactory<AuthViewModel> _authVMFactory;
        private readonly ICarPartViewModelFactory<RegisterViewModel> _registerVMFactory;

        public CarPartViewModelAbstractFactory(ICarPartViewModelFactory<RegisterViewModel> registerVmFactory, ICarPartViewModelFactory<AuthViewModel> authVmFactory)
        {
            _registerVMFactory = registerVmFactory;
            _authVMFactory = authVmFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.AUTH:
                    return _authVMFactory.CreateViewModel();
                case ViewType.REGISTER:
                    return _registerVMFactory.CreateViewModel();
                default:
                    throw new ArgumentException("Uncorrect viewType parametr", "viewType");
            }
        }
    }
}
