using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Cart:DomainObject
    {
        [Key]
        public override int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int PartId { get; set; }
        public int ProviderId { get; set; }
        public int CarId { get; set; }
        public int Amount { get; set; }


    }
}
