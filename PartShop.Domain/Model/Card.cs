using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Card:DomainObject
    {
        public int Cash { get; set; }
        public int Pin { get; set; }
        public DateTime FinishDate { get; set; }
        public Account Account { get; set; }
    }
}
