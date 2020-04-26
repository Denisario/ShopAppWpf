using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Card
    {
        public int Id { get; set; }
        public int Cash { get; set; }
        public Account Account { get; set; }
    }
}
