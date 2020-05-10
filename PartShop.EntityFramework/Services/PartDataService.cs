using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework.Services.Common;

namespace PartShop.EntityFramework.Services
{
    public class PartDataService:IPartService
    {
        private readonly NonQueryDataService<Part> _nonQueryDataService;
        private readonly CarPartDbContextFactory _contextFactory;

        public PartDataService(CarPartDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService=new NonQueryDataService<Part>(_contextFactory);
        }

        public async Task<IEnumerable<Part>> GetAll()
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Part> parts = await context
                                                .Parts.Include(a => a.PartProviders)
                                                .Include(b => b.CarParts)
                                                .ToListAsync();

                return parts;
            }
        }

        public async Task<Part> Get(int id)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                Part entity = await context.Parts
                    .Include(a => a.PartProviders)
                    .Include(b=>b.CarParts)
                    .FirstOrDefaultAsync(e => e.Id == id);

                return entity;
            }
        }

        public async Task<Part> Create(Part entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<Part> Update(int id, Part entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<bool> AddPart(Part part, int providerId, int carId, int amountParts, double price)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                Part entity = await context.Parts
                    .Include(a => a.PartProviders)
                    .Include(b => b.CarParts)
                    .FirstOrDefaultAsync(i =>
                        i.Name == part.Name && i.Color == part.Color && i.Description == part.Description);

                if (entity == null)
                {
                    part.CarParts.Add(new PartShop.Domain.Model.CarPart()
                    {
                        PartId = part.Id,
                        CarId = carId
                    });

                    part.PartProviders.Add(new PartProvider()
                    {
                        PartId = part.Id,
                        ProviderId = providerId,
                        TotalParts = amountParts,
                        PartCost = price
                    });

                    await Create(part);
                }
                else
                {

                    //ТУТ БАГ НАДО ПОФИКСИТЬ И ДОБАВИТЬ ОБНОВЛЕНИЕ ЦЕНЫ
                    entity.CarParts.Add(new PartShop.Domain.Model.CarPart()
                        {
                            PartId = entity.Id,
                            CarId = carId
                        });

                    entity.PartProviders.Add(new PartProvider()
                        {
                            PartId = entity.Id,
                            ProviderId = providerId,
                            TotalParts = amountParts,
                            PartCost = price
                        });
                        await SaveProviderAndCar(entity);
                }

                return true;
            }
        }

        public async Task<bool> SaveProviderAndCar(Part part)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                await context.PartProviders.AddAsync(part.PartProviders.Last());
                  
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
