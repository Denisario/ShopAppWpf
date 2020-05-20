using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("Cart")]
    public class Cart:DomainObject
    {
        [Key]
        [Column("id")]
        public override int Id { get; set; }
        [Column("account_id")]
        public int AccountId { get; set; }
        public Account Account { get; set; }
        [Column("part_id")]
        public int PartId { get; set; }
        [Column("provider_id")]
        public int ProviderId { get; set; }
        [Column("car_id")]
        public int CarId { get; set; }
        [Column("amount")]
        public int Amount { get; set; }


    }
}
