using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Card
    {
        [Key]
        public long CardNumber { get; set; }
        public double Balance { get; set; }
        public string PinCode { get; set; }
        public int Attempts { get; set; } 
        public DateTime CreationDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
