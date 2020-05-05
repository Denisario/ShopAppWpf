using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class OrderParts
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int PartId { get; set; }
        public Part Part { get; set; }
    }
}
