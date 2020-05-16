using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;
using Microsoft.Extensions.DependencyInjection;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    public class CartViewModelFactory:ICarPartViewModelFactory<CartViewModel>
    {
        private readonly IAuthentificator _authentificator;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public CartViewModelFactory(IAuthentificator authentificator, ICartService cartService, IOrderService orderService)
        {
            _authentificator = authentificator;
            _cartService = cartService;
            _orderService = orderService;
        }

        public CartViewModel CreateViewModel()
        {
            
            return new CartViewModel(_authentificator, _cartService, _orderService);
        }
    }
}
