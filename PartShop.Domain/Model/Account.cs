using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User AccountHolder { get; set; }

        public int Balance { get; set; }
        public IEnumerable<Card> AccountCards { get; set; }
        
       // public IEnumerable<Order> AccountOrders { get; set; }
    }
}
