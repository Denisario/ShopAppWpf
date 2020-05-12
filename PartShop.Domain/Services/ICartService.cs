using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface ICartService:IDataService<Cart>
    {
        Task<IEnumerable<Cart>> GetAllPartsInCartByAccount(int accountId);

        Task<Account> AddPartToCart(PartFullInfo partFullInfo, Account account, int amount);
    }
}
