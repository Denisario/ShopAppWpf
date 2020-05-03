using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Account:DomainObject
    {
        [Key]
        [ForeignKey("User")]
        public override int Id { get; set; }
        public string Phone { get; set; }
        public int Balance { get; set; }

        public DateTime CreationDate { get; set; }

        public string Status { get; set; }

        public User User { get; set; }

        public IEnumerable<Card> AccountCards { get; set; }

        
       public IEnumerable<Order> Orders { get; set; }
    }
}
