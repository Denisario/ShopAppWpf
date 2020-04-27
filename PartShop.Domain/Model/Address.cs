using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Address:DomainObject
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Apartament { get; set; }
        public int PostCode { get; set; }
        public Order Order { get; set; }
    }
}
