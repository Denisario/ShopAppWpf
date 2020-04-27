using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Order
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public DateTime CreaationDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Status { get; set; }
        public IEnumerable<PartOrder> PartOrders { get; set; }
        public Address Address { get; set; }
    }
}
