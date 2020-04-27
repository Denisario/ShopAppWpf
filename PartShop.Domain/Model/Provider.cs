using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public bool HasPart { get; set; }
        public int PartCost { get; set; }

        public Part Part { get; set; }
    }
}
