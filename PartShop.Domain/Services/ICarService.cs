using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface ICarService:IDataService<Car>
    {
        Task<IEnumerable<string>> GetAllMarks();
        Task<IEnumerable<string>> GetAllModels(string mark);
    }
}
