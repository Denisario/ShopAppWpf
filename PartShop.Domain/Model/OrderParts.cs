using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("OrderParts")]
    public class OrderParts
    {
        [Column("order_id")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Column("part_id")]
        public int PartId { get; set; }
        public Part Part { get; set; }
        [Column("provider_id")]
        public int ProviderId { get; set; }
        [Column("amount")]
        public int AmountPart { get; set; }
        [Column("price")]
        public double Price { get; set; }
    }
}
