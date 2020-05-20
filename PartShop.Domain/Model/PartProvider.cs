using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("PartProviders")]
    public class PartProvider
    {
        [Column("part_id")]
        public int PartId { get; set; }
        public Part Part { get; set; }
        [Column("provider_id")]
        public int ProviderId  { get; set; }
        public Provider Provider{ get; set; }
        [Column("amount")]
        [Range(0, 99999,ErrorMessage = "Число запчастей не может быть отрицательным")]
        public int TotalParts { get; set; }
        [Column("price")]
        [Range(0, 99999, ErrorMessage = "Цена не может быть отрицательной")]
        public double PartCost { get; set; }
    }
}
