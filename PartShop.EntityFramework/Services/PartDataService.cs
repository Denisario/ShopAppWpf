using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private IEmailService _emailService;
        public PartDataService(CarPartDbContextFactory contextFactory, IEmailService emailService)
        {
            _contextFactory = contextFactory;
            _emailService = emailService;
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
                var results = new List<ValidationResult>();
                var partContext = new ValidationContext(part);

                StringBuilder errorResult = new StringBuilder();

                if (!Validator.TryValidateObject(part, partContext, results, true))
                {
                    foreach (var error in results)
                    {
                        errorResult.Append(error.ErrorMessage + '\n');
                    }


                    //переделать
                    if (amountParts <= 0) errorResult.Append("Неверно задано число запчастей\n");
                    if (price <= 0) errorResult.Append("Неверная ценв\n");

                    
                    throw new Exception(errorResult.ToString());
                }

                bool success = true;
                Part entity = await context.Parts
                    .Include(a => a.PartProviders)
                    .Include(b => b.CarParts)
                    .FirstOrDefaultAsync(i =>
                        i.Name == part.Name && i.Color == part.Color && i.Description == part.Description);//ещё проверки

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
                    success=await SaveProviderAndCar(entity, amountParts, price);

                }

                return success;
            }
        }

        //НЕ СМОТРЕТЬ НА ЭТОТ УЖАС
        public async Task<bool> SaveProviderAndCar(Part part, int amountParts,double price)
        {

            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                _addCarPartFlag = false;
                _addPartProviderFlag = false;

                
                PartProvider possibblePartProvider = part.PartProviders.Last();
                CarPart possibleCarPart = part.CarParts.Last();

                if (context.PartProviders.Where(a => a.PartId == possibblePartProvider.PartId && a.ProviderId == possibblePartProvider.ProviderId).Count() == 0)
                {
                    _addPartProviderFlag = true;
                    await context.PartProviders.AddAsync(possibblePartProvider);
                    await context.SaveChangesAsync();
                }
                else
                {
                    PartProvider pp = await context.PartProviders.FirstOrDefaultAsync(x =>
                        x.PartId == possibblePartProvider.PartId && x.ProviderId == possibblePartProvider.ProviderId);

                    pp.PartCost = price;
                    pp.TotalParts += amountParts;

                    context.PartProviders.Update(pp);
                    await context.SaveChangesAsync();

                    foreach (var p in context.Accounts.Include(a=>a.Carts))
                    {
                        foreach (var l in p.Carts)
                        {
                            if (l.PartId == pp.PartId)
                               await _emailService.SendPartEmail(p, "Поступление на склад",
                                    $"Сообщаем Вам о том, что запчать из вашей корзины(id: {pp.PartId}) поступила в продажу");
                        }
                    }
                }

                

                if (context.CarParts.Where(a=>a.PartId==possibleCarPart.PartId&&a.CarId==possibleCarPart.CarId).Count()==0)
                {
                    //_addCarPartFlag= true;
                    await context.CarParts.AddAsync(possibleCarPart);
                    await context.SaveChangesAsync();
                }
                //туть баг
                if (/*_addCarPartFlag == false &&*/ _addPartProviderFlag == false)
                {
                    return false;
                }
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
                            PartArticle = @t.part.Article,
                            PartCategory = @t.part.Category,
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
