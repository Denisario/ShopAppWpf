using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class PartProvider
    {
        public int PartId { get; set; }
        public Part Part { get; set; }
        public int ProviderId  { get; set; }
        public Provider Provider{ get; set; }
        public int TotalParts { get; set; }
        public double PartCost { get; set; }

    }
}
