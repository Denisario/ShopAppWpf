using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace PartShop.EntityFramework.Services
{
    public class PartProviderService:IPartProviderService
    {
        private readonly CarPartDbContextFactory _contextFactory;

        public PartProviderService(CarPartDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<PartProvider> AddPartProvider(Part part, Provider provider)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                PartProvider pp = new PartProvider()
                {
                    Part = part,
                    Provider = provider
                };
                EntityEntry<PartProvider> createdResult = await context.Set<PartProvider>().AddAsync(pp);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }
    }
}
