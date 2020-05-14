using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface IOrderService
    {
        Task<double> CreateOrder(Account account,List<PartFullInfo> partInCar);
    }
}
