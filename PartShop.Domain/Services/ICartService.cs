using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface ICartService:IDataService<Cart>
    {

        Task AddPartToCart(PartFullInfo partFullInfo, Account account, int amount);

        Task<IEnumerable<PartFullInfo>> GetAllPartsInView(Account account);

        Task DeletePartFromCart(List<PartFullInfo> partFullInfo, Account account);
    }
}
