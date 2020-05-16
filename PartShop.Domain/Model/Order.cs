using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Order:DomainObject
    {
        public override int Id { get; set; }
        public DateTime OrderCreationTime { get; set; }
        public DateTime FinishDate { get; set; }
        public OrderStatus Status { get; set; }
        public Address Address { get; set; }
        public List<OrderParts> Parts { get; set; }
        [NotMapped] public string AddressStr { get=> Address.ToString(); } 
    }
}
