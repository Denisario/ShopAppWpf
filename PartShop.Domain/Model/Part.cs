using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Part:DomainObject
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public List<CarPart> CarParts { get; set; }
        public List<PartProvider> PartProviders { get; set; }
    }
}
