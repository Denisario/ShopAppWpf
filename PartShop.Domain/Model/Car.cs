using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public String Model { get; set; }
        public int Year { get; set; }

        public IEnumerable<CarPart> CarParts { get; set; }
    }
}
