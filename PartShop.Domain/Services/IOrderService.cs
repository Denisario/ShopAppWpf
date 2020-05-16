using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface IOrderService:IDataService<Order>
    {
        Task<double> CreateOrder(Account account,List<PartFullInfo> partInCar);
        Task<bool> PrintCheck(int orderId);
        Task<bool> CancelOrder(Account account,Order order);
        Task<bool> FinishOrder(Order order);
        Task<bool> DelivOrder(Order order);
    }
}
