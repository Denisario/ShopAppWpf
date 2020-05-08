using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;

namespace PartShop.Domain.Services
{
    public interface IPartProviderService
    {
        Task<PartProvider> AddPartProvider(Part part, Provider provider);
    }
}
