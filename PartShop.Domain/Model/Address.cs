using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Address:DomainObject
    {
        [ForeignKey("Order")]
        public override int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Apartament { get; set; }
        public Order Order { get; set; }


        public override string ToString()
        {
            return $"{City} city, {Street} str, {House}-{Apartament}";
        }
    }
}
