using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CarPart> CarParts { get; set; }
        public IEnumerable<PartOrder> PartOrders { get; set; }
        public IEnumerable<Provider> Providers { get; set; }
    }
}
