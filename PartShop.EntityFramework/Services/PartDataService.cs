﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework.Services.Common;

namespace PartShop.EntityFramework.Services
{
    class PartDataService:IPartService
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

        public Task<Part> Update(int id, Part entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            return _nonQueryDataService.Delete(id);
        }
    }
}
