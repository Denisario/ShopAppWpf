using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("Cards")]
    public class Card
    {
        [Key]
        [Column("number")]
        public long CardNumber { get; set; }
        [Column("balance")]
        public double Balance { get; set; }
        [Column("pin")]
        [Required(ErrorMessage = "Пин обязателен")]
        public string PinCode { get; set; }
        [Column("attempts")]
        public int Attempts { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        [Column("finish_date")]
        [Required(ErrorMessage = "Срок окончания обязателен")]
        public DateTime FinishDate { get; set; }
    }
}
