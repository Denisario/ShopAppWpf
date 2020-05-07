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
        private readonly ICarPartViewModelFactory<HomeViewModel> _homeVmFactory;
        private readonly ICarPartViewModelFactory<PartViewModel> _partVmFactory;

        public CarPartViewModelAbstractFactory(ICarPartViewModelFactory<RegisterViewModel> registerVmFactory,
                                               ICarPartViewModelFactory<AuthViewModel> authVmFactory,
                                               ICarPartViewModelFactory<HomeViewModel> homeVmFactory,
                                               ICarPartViewModelFactory<PartViewModel> partVmFactory)
        {
            _registerVMFactory = registerVmFactory;
            _authVMFactory = authVmFactory;
            _homeVmFactory = homeVmFactory;
            _partVmFactory = partVmFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.AUTH:
                    return _authVMFactory.CreateViewModel();
                case ViewType.REGISTER:
                    return _registerVMFactory.CreateViewModel();
                case ViewType.HOME:
                    return _homeVmFactory.CreateViewModel();
                case ViewType.PARTS:
                    return _partVmFactory.CreateViewModel();
                default:
                    throw new ArgumentException("Uncorrect viewType parametr", "viewType");
            }
        }
    }
}
