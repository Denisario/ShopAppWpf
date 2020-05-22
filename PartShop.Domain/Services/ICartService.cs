﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface ICartService:IDataService<Cart>
    {

        Task<Account> AddPartToCart(PartFullInfo partFullInfo, Account account, int amount);

        Task<IEnumerable<PartFullInfo>> GetAllPartsInView(Account account);

        Task<Cart> DeletePartFromCart(List<PartFullInfo> partFullInfo, Account account);
    }
}
