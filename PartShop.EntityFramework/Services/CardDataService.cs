using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<double> CreateCard(int password, DateTime finishDate)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                if(password<1000&&password>9999) throw new Exception("Пин должен быть четырёхзначным");
                if(finishDate<DateTime.Now) throw new Exception("Срок окончания не должен превышать текущую дату");

                double balance = new Random().Next(300, 3300);

                await context.Cards.AddAsync(new Card()
                {
                    Attempts = 3,
                    Balance = balance,
                    CreationDate = DateTime.Now.Date,
                    FinishDate = finishDate,
                    PinCode = HashPass(password.ToString())
                });

                await context.SaveChangesAsync();

                return balance;
            }
        }

        public async Task<double> Withdraw(Account account,Card card)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                var results = new List<ValidationResult>();
                var addrContext = new ValidationContext(card);

                StringBuilder errorResult = new StringBuilder();

                if (!Validator.TryValidateObject(card, addrContext, results, true))
                {
                    foreach (var error in results)
                    {
                        errorResult.Append(error.ErrorMessage + '\n');
                    }
                    throw new Exception(errorResult.ToString());
                }

                if (card.Pin == 0) throw new Exception("Пин обязателен");
                
                Card checkCard =await context.Cards.FirstOrDefaultAsync(p => p.CardNumber == card.CardNumber);
                if (checkCard == null) throw new Exception("Карта не найдена");
                if (checkCard.Attempts == 1) throw new Exception("Карта заблокирована");
                if(checkCard.FinishDate.Equals(card.FinishDate)) throw new Exception("Неверная дата окончания");
                if (checkCard.Balance < card.Balance) throw new Exception("На карте отсутсвует данная сумма");
                if (checkCard.PinCode == HashPass(card.Pin.ToString()))
                {
                    checkCard.Balance -= card.Balance;
                }
                else
                {
                    checkCard.Attempts--;
                    throw new Exception($"Неверный пароль. Попыток до блокировки: {checkCard.Attempts}");
                }
                account.Balance += card.Balance;

                context.Cards.Update(checkCard);
                context.Accounts.Update(account);

                await context.SaveChangesAsync();

                return card.Balance;
            }
        }

        public async Task<long> GetNumberOfCard()
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                List<Card> card = await context.Cards.ToListAsync();
                if (card.Count() == 0) return 5772000000000000;
                return card.Last().CardNumber + 1;
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
