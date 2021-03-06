﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface ICardService
    {
        Task<double> CreateCard(int password, DateTime finishDate);

        Task<double> Withdraw(Account account, Card card);

        Task<long> GetNumberOfCard();
    }
}
