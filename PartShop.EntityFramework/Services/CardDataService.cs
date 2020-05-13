using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace PartShop.EntityFramework.Services
{
    public class CardDataService:ICardService
    {
        private readonly CarPartDbContextFactory _contextFactory;

        public CardDataService(CarPartDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> CreateCard(int password, DateTime finishDate)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                await context.Cards.AddAsync(new Card()
                {
                    Attempts = 3,
                    Balance = new Random().Next(300, 3300),
                    CreationDate = DateTime.Now.Date,
                    FinishDate = finishDate,
                    PinCode = HashPass(password.ToString())
                });

                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<double> Withdraw(Account account, long cardNumber, int pin, DateTime finishCardDate, double money)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                Card checkCard =await context.Cards.Where(p => p.CardNumber == cardNumber).FirstAsync();
                if (checkCard == null) return 0.0;
                if (checkCard.Attempts == 0||!checkCard.FinishDate.Equals(finishCardDate)) return 0.0;
                if (checkCard.Balance < money) return 0.0;
                if (checkCard.PinCode == HashPass(pin.ToString()))
                {
                    checkCard.Balance -= money;
                }
                else
                {
                    checkCard.Attempts--;
                }
                account.Balance += money;

                context.Cards.Update(checkCard);
                context.Accounts.Update(account);

                await context.SaveChangesAsync();

                return money;
            }
        }

        private string HashPass(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
