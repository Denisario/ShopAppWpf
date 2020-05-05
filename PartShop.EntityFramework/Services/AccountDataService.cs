using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartShop.Domain.Exceptions;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework.Services.Common;

namespace PartShop.EntityFramework.Services
{
    public class AccountDataService:IDataService<Account>
    {
        private readonly CarPartDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;
        public AccountDataService(CarPartDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService=new NonQueryDataService<Account>(contextFactory);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entity = await context.Accounts
                    .Include(a => a.Orders)
                    .ToListAsync();

                if (entity == null) throw new UserNotFoundException("User not found");

                return entity;
            }
        }

        public async Task<Account> Get(int id)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts
                    .Include(a => a.Orders)
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (entity == null) throw new UserNotFoundException("User not found");

                return entity;
            }
        
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
        //СМЫСЛ УДАЛЯТЬ АККАУНТ???
        public async Task<bool> Delete(int id)
        {
            //return await _nonQueryDataService.Delete(id);
            return false;
        }
    }
}
