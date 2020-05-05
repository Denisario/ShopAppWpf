using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Car:DomainObject
    {
        [Key]
        public override int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }
        public int CreationYear { get; set; }
        public List<CarPart> CarParts { get; set; }
    }
}
