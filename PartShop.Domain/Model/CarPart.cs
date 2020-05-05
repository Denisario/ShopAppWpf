using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class CarPart
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int PartId { get; set; }
        public Part Part { get; set; }
    }
}
