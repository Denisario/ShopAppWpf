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
    public class CarDataService:ICarService
    {
        private readonly NonQueryDataService<Car> _nonQueryDataService;
        private readonly CarPartDbContextFactory _contextFactory;

        public CarDataService(CarPartDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Car>(contextFactory);
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Car> cars = await context.Cars.ToListAsync();

                return cars;
            }
        }

        public async Task<Car> Get(int id)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                Car car = await context.Cars.FirstOrDefaultAsync(i=>i.Id==id);

                return car;
            }
        }

        public async Task<Car> Create(Car entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<Car> Update(int id, Car entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<IEnumerable<string>> GetAllMarks()
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<string> carMarks = await context.Cars.Select(i=>i.Mark).Distinct().ToListAsync();
                return carMarks;
            }
        }

        public async Task<IEnumerable<string>> GetAllModels(string mark)
        {
            using (CarPartDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<string> carMarks = await context.Cars.Where(m=>m.Mark==mark).Select(i => i.Model).Distinct().ToListAsync();
                return carMarks;
            }
        }
    }
}
