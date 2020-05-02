using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Order:DomainObject
    {
        [ForeignKey("Address")]
        public override int Id { get; set; }
        public Account Account { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Status { get; set; }
        public IEnumerable<PartOrder> PartOrders { get; set; }

        public Address Address { get; set; }
    }
}
