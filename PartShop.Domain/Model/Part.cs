using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Part:DomainObject
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public IEnumerable<CarPart> CarParts { get; set; }
        public IEnumerable<PartOrder> PartOrders { get; set; }
        public IEnumerable<Provider> Providers { get; set; }
    }
}
