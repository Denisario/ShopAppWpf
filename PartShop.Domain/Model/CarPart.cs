using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("CarParts")]
    public class CarPart
    {
        [Column("car_id")]
        public int CarId { get; set; }
        public Car Car { get; set; }
        [Column("part_id")]
        public int PartId { get; set; }
        public Part Part { get; set; }
    }
}
