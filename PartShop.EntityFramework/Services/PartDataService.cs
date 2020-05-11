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
        private bool _addPartProviderFlag;
        private bool _addCarPartFlag;

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
                bool success = true;
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

                    //ТУТ ДОБАВИТЬ ОБНОВЛЕНИЕ ЦЕНЫ
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
                    success=await SaveProviderAndCar(entity);
                }

                return success;
            }
        }

        //НЕ СМОТРЕТЬ НА ЭТОТ УЖАС
        public async Task<bool> SaveProviderAndCar(Part part)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                PartProvider possibblePartProvider = part.PartProviders.Last();
                CarPart possibleCarPart = part.CarParts.Last();

                if (context.PartProviders.Where(a => a.PartId == possibblePartProvider.PartId && a.ProviderId == possibblePartProvider.ProviderId).Count() == 0)
                {
                    _addPartProviderFlag = true;
                    await context.PartProviders.AddAsync(possibblePartProvider);
                    await context.SaveChangesAsync();
                }

                if (context.CarParts.Where(a=>a.PartId==possibleCarPart.PartId&&a.CarId==possibleCarPart.CarId).Count()==0)
                {
                    _addCarPartFlag= true;
                    await context.CarParts.AddAsync(possibleCarPart);
                    await context.SaveChangesAsync();
                }

                if (_addCarPartFlag == false || _addPartProviderFlag == false) return false;
                return true;
            }
        }

        public async Task<IEnumerable<PartFullInfo>> GetAllPartsForView()
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<PartFullInfo> parts = await context.Parts
                    .Join(context.PartProviders, part => part.Id, partprovider => partprovider.PartId,
                        (part, partprovider) => new {part, partprovider})
                    .Join(context.CarParts, @t => @t.partprovider.PartId, carpart => carpart.PartId,
                        (@t, carpart) => new PartFullInfo()
                        {
                            PartId = @t.part.Id,
                            ProviderId = @t.partprovider.ProviderId,
                            PartName = @t.part.Name,
                            PartColor = @t.part.Color,
                            PartDescription = @t.part.Description,
                            ProviderName = @t.partprovider.Provider.Name,
                            ProviderPartAmount = @t.partprovider.TotalParts,
                            ProviderPartPrice = @t.partprovider.PartCost,
                            CarMark = carpart.Car.Mark,
                            CarModel = carpart.Car.Model,
                            CarCreationYear = carpart.Car.CreationYear,
                            CarFuelType = carpart.Car.FuelType,
                            CarId = carpart.CarId
                        }).ToListAsync();

                return parts;
            }
        }
    }
}
