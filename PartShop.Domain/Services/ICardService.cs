using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PartShop.Domain.Services
{
    public interface ICardService
    {
        Task<bool> CreateCard(int password, DateTime finishDate);

        Task<double> Withdraw(double money);
    }
}
