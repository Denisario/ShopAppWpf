using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory:ICarPartViewModelFactory<HomeViewModel>
    {
        private readonly IAuthentificator _authentificator;
        private readonly IOrderService _orderService;

        public HomeViewModelFactory(IAuthentificator authentificator, IOrderService orderService)
        {
            _authentificator = authentificator;
            _orderService = orderService;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_authentificator, _orderService);
        }
    }
}
