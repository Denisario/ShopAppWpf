using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace PartShop.EntityFramework.Service
{
    public class GenericDataService<T>:IDataService<T> where T:DomainObject
    {
        private readonly CarPartDbContextFactory _contentFactory;

        public GenericDataService(CarPartDbContextFactory contentFactory)
        {
            _contentFactory = contentFactory;
        }
        public async Task<IEnumerable<T>> GetAll()
        {

            using (CarPartDbContext context = _contentFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Get(int id)
        {
            using (CarPartDbContext context = _contentFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync(s => s.Id == id);
                return entity;
            }
        }

        public async Task<T> Create(T entity)
        {
            using (CarPartDbContext context= _contentFactory.CreateDbContext())
            {
                EntityEntry<T> createdEntity=await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdEntity.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (CarPartDbContext context = _contentFactory.CreateDbContext())
            {
                entity.Id = id;
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (CarPartDbContext context = _contentFactory.CreateDbContext())
            {
               T entity = await context.Set<T>().FirstOrDefaultAsync(s=>s.Id==id);
               context.Set<T>().Remove(entity);
               await context.SaveChangesAsync();

               return true;
            }
        }
    }
}
