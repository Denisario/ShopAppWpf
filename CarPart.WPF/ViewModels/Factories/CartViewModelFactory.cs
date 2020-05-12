using System;
using System.Collections.Generic;
using System.Text;

namespace CarPart.WPF.ViewModels.Factories
{
    public class CartViewModelFactory:ICarPartViewModelFactory<CartViewModel>
    {
        public CartViewModel CreateViewModel()
        {
            return new CartViewModel();
        }
    }
}
