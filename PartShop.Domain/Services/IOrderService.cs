using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface IOrderService:IDataService<Order>
    {
        Task<double> CreateOrder(Account account,List<PartFullInfo> partInCar, Address address);
        Task PrintCheck(Order order, string path);
        Task CancelOrder(Account account,Order order);
        Task FinishOrder(Order order);
        Task DelivOrder(Order order);
    }
}
