using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework.Services.Common;

namespace PartShop.EntityFramework.Services
{
    public class CartDataService:ICartService
    {
        private readonly CarPartDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Cart> _nonQueryDataService;
        private readonly IPartService _partService;

        public CartDataService(CarPartDbContextFactory contextFactory, IPartService partService)
        {
            _contextFactory = contextFactory;
            _partService = partService;
            _nonQueryDataService=new NonQueryDataService<Cart>(contextFactory);
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Cart> entity = await context.Carts.ToListAsync();

                return entity;
            }
        }

        public async Task<Cart> Get(int id)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                Cart entity = await context.Carts.FirstOrDefaultAsync(e => e.Id == id);
                return entity;
            }
        }

        public async Task<Cart> Create(Cart entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<Cart> Update(int id, Cart entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<IEnumerable<Cart>> GetAllPartsInCartByAccount(int accountId)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Cart> entity = await context.Carts.Where(e => e.AccountId == accountId).ToListAsync();
                return entity;
            }
        }

        public async Task<Account> AddPartToCart(PartFullInfo partFullInfo, Account account, int amount=1)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                account.Carts.Add(new Cart()
                {
                    Amount = amount,
                    CarId = partFullInfo.CarId,
                    PartId = partFullInfo.PartId,
                    ProviderId = partFullInfo.ProviderId,
                    AccountId = account.Id
                });
                context.Carts.Add(new Cart()
             {
                 Amount = amount,
                 CarId=partFullInfo.CarId,
                 PartId = partFullInfo.PartId,
                 ProviderId = partFullInfo.ProviderId,
                 AccountId = account.Id
             });
             await context.SaveChangesAsync();
             return account;
            }
        }

        public async Task<IEnumerable<PartFullInfo>> GetAllPartsInView(Account account)
        {
            List<PartFullInfo> parts = new List<PartFullInfo>(await _partService.GetAllPartsForView());
            List<PartFullInfo> result = new List<PartFullInfo>();

            foreach (var p in account.Carts)
            {
                //проверить
                PartFullInfo part = parts.FirstOrDefault(c=>c.PartId==p.PartId&&c.CarId==p.CarId&&c.ProviderId==p.ProviderId);
                part.ProviderPartAmount = p.Amount;

                result.Add(part);
            }

            return result;
        }
    }
}
