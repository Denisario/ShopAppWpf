﻿using System;
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
                //IEnumerable<Cart> entity = await context.Carts.ToListAsync();
                //return entity;

                return await context.Carts.ToListAsync();
            }
        }

        public async Task<Cart> Get(int id)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                //Cart entity = await context.Carts.FirstOrDefaultAsync(e => e.Id == id);
                //return entity;

                return await context.Carts.FirstOrDefaultAsync(e => e.Id == id);
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

        public async Task AddPartToCart(PartFullInfo partFullInfo, Account account, int amount=1)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                if(partFullInfo==null) throw new Exception("Вы не выбрали запчасть");
                Cart cart = await context.Carts
                                         .FirstOrDefaultAsync(x => x.PartId == partFullInfo.PartId
                                                                   && x.ProviderId == partFullInfo.ProviderId
                                                                   && x.AccountId==account.Id);
                
                if (cart == null)
                {
                    await Create(new Cart()
                    {
                        Amount = amount,
                        CarId = partFullInfo.CarId,
                        PartId = partFullInfo.PartId,
                        ProviderId = partFullInfo.ProviderId,
                        AccountId = account.Id
                    });
                }
                else
                {
                    cart.Amount += amount;
                    context.Carts.Update(cart);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PartFullInfo>> GetAllPartsInView(Account account)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                account.Carts = await context.Carts.Where(x => x.AccountId == account.Id).ToListAsync();

                List<PartFullInfo> parts = new List<PartFullInfo>(await _partService.GetAllPartsForView());
                List<PartFullInfo> result = new List<PartFullInfo>();

                foreach (var p in account.Carts)
                {
                    //проверить!!!!
                    PartFullInfo part = parts.FirstOrDefault(c => c.PartId == p.PartId && c.CarId == p.CarId && c.ProviderId == p.ProviderId);
                    part.ProviderPartAmount = p.Amount;

                    result.Add(part);
                }

                return result;
            }
        }

        public async Task DeletePartFromCart(List<PartFullInfo> partFullInfo, Account account)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                if (partFullInfo.Count()==0) throw new Exception("Вы не выбрали запчасть для удаления");

                foreach (var pp in partFullInfo)
                {
                    Cart partForDeleting = await context.Carts
                                                        .FirstOrDefaultAsync(p =>
                                                                                     p.PartId == pp.PartId &&
                                                                                     p.ProviderId == pp.ProviderId &&
                                                                                     p.CarId == pp.CarId);

                    await Delete(partForDeleting.Id);
                    account.Carts.Remove(partForDeleting);
                }
            }
        }
    }
}
