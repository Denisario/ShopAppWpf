using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    public class CartViewModelFactory:ICarPartViewModelFactory<CartViewModel>
    {
        private readonly IAuthentificator _authentificator;
        private readonly ICartService _cartService;

        public CartViewModelFactory(IAuthentificator authentificator, ICartService cartService)
        {
            _authentificator = authentificator;
            _cartService = cartService;
        }

        public CartViewModel CreateViewModel()
        {
            
            return new CartViewModel(_authentificator, _cartService);
        }
    }
}
