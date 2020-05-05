using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Provider:DomainObject
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public List<PartProvider> PartProviders { get; set; }
    }
}
