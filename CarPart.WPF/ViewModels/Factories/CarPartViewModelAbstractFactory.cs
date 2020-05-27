using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using PartShop.Domain.Model;

namespace CarPart.WPF.ViewModels.Factories
{
    public class CarPartViewModelAbstractFactory:ICarPartViewModelAbstractFactory
    {
        private readonly ICarPartViewModelFactory<AuthViewModel> _authVMFactory;
        private readonly ICarPartViewModelFactory<RegisterViewModel> _registerVMFactory;
        private readonly ICarPartViewModelFactory<HomeViewModel> _homeVmFactory;
        private readonly ICarPartViewModelFactory<PartViewModel> _partVmFactory;
        private readonly ICarPartViewModelFactory<AdminViewModel> _adminVmFactory;
        private readonly ICarPartViewModelFactory<CartViewModel> _cartVmFactory;
        private readonly IAuthentificator _authentificator;

        public CarPartViewModelAbstractFactory(ICarPartViewModelFactory<RegisterViewModel> registerVmFactory,
                                               ICarPartViewModelFactory<AuthViewModel> authVmFactory,
                                               ICarPartViewModelFactory<HomeViewModel> homeVmFactory,
                                               ICarPartViewModelFactory<PartViewModel> partVmFactory,
                                               ICarPartViewModelFactory<AdminViewModel> adminVmFactory,
                                               ICarPartViewModelFactory<CartViewModel> cartVmFactory,
                                               IAuthentificator authentificator)
        {
            _registerVMFactory = registerVmFactory;
            _authVMFactory = authVmFactory;
            _homeVmFactory = homeVmFactory;
            _partVmFactory = partVmFactory;
            _adminVmFactory = adminVmFactory;
            _cartVmFactory = cartVmFactory;
            _authentificator = authentificator;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.AUTH:
                    if (_authentificator.IsLoggedIn) return _homeVmFactory.CreateViewModel();
                    return _authVMFactory.CreateViewModel();
                case ViewType.REGISTER:
                    if (_authentificator.IsLoggedIn)  return _homeVmFactory.CreateViewModel();
                    return _registerVMFactory.CreateViewModel();
                case ViewType.HOME:
                    if (_authentificator.IsLoggedIn == false) return _authVMFactory.CreateViewModel();
                    if (_authentificator.CurrentAccount.UserRole == Role.ADMIN) return _adminVmFactory.CreateViewModel();
                    return _homeVmFactory.CreateViewModel();
                case ViewType.PARTS:
                    return _partVmFactory.CreateViewModel();
                case ViewType.ADMIN:
                    return _adminVmFactory.CreateViewModel();
                case ViewType.CART:
                    if (_authentificator.IsLoggedIn == false) return _authVMFactory.CreateViewModel();
                    return _cartVmFactory.CreateViewModel();
                default:
                    throw new ArgumentException("Uncorrect viewType parametr", "viewType");
            }
        }
    }
}
