using System;
using System.Collections.Generic;
using System.Text;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    public class OrderViewModelFactory:ICarPartViewModelFactory<OrderViewModel>
    {
        private readonly IOrderService _orderService;

        public OrderViewModelFactory(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public OrderViewModel CreateViewModel()
        {
            return new OrderViewModel(_orderService);
        }
    }
}
