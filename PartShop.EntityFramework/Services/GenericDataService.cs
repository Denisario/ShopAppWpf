using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework.Services.Common;

namespace PartShop.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly CarPartDbContextFactory _contentFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(CarPartDbContextFactory contentFactory)
        {
            _contentFactory = contentFactory;
            _nonQueryDataService = new NonQueryDataService<T>(contentFactory);
        }
        public async Task<IEnumerable<T>> GetAll()
        {

            using (CarPartDbContext context = _contentFactory.CreateDbContext())
            {
                //IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                //return entities;

                return await context.Set<T>().ToListAsync();
            }
        }

        public async Task<T> Get(int id)
        {
            using (CarPartDbContext context = _contentFactory.CreateDbContext())
            {
                //T entity = await context.Set<T>().FirstOrDefaultAsync(s => s.Id == id);
                //return entity;

                return await context.Set<T>().FirstOrDefaultAsync(s => s.Id == id);
            }
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }
    }
}
