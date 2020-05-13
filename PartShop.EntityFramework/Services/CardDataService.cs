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
                    CreationDate = DateTime.Now,
                    FinishDate = finishDate,
                    PinCode = HashPass(password.ToString())
                });

                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<double> Withdraw(double money)
        {
            return 0.1d;
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
