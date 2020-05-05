using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface IAccountService:IDataService<Account>
    {
        Task<Account> GetAccountByUsername(string username);

    }
}
