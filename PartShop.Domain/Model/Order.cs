using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("Orders")]
    public class Order:DomainObject
    {
        [Column("id")]
        public override int Id { get; set; }
        [Column("creation_time")]
        public DateTime OrderCreationTime { get; set; }
        [Column("finish_time")]
        public DateTime? FinishDate { get; set; }
        [Column("status")]
        public OrderStatus Status { get; set; }
        public Address Address { get; set; }
        [Column("account_id")]
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public List<OrderParts> Parts { get; set; }
        [NotMapped] public string AddressStr { get=> Address.ToString(); } 
    }
}
