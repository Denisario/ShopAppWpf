using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface IPartService:IDataService<Part>
    {
        Task<bool> AddPart(Part part, int providerId, int carId, int amountParts, double price);
        Task<bool> SaveProviderAndCar(Part part);
    }
}
