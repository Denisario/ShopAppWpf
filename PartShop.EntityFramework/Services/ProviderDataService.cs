using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework.Services.Common;

namespace PartShop.EntityFramework.Services
{
   public  class ProviderDataService:IProviderService
    {
        private readonly NonQueryDataService<Provider> _nonQueryDataService;
        private readonly CarPartDbContextFactory _contextFactory;

        public ProviderDataService(CarPartDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Provider>(contextFactory);
        }

        public async Task<IEnumerable<Provider>> GetAll()
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Provider> providers = await context.Providers.ToListAsync();

                return providers;
            }
        }

        public async Task<Provider> Get(int id)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                Provider provider = await context.Providers.FirstOrDefaultAsync(i => i.Id == id);

                return provider;
            }
        }

        public async Task<Provider> Create(Provider entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity);

            StringBuilder errorResult = new StringBuilder();

            if (!Validator.TryValidateObject(entity, context, results, true))
            {
                foreach (var error in results)
                {
                    errorResult.Append(error.ErrorMessage + '\n');
                }
                throw new Exception(errorResult.ToString());
            }

            return await _nonQueryDataService.Create(entity);
        }

        public async Task<Provider> Update(int id, Provider entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }
    }
}
