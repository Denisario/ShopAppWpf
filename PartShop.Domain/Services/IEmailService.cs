using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface IEmailService
    {
        Task SendOrderEmail(Order order, string header, string text);
        Task SendPartEmail(Account account,string header, string text);
    }
}
