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
        [Range(5772000000000000, 5772999999999999, ErrorMessage = "Неверный формат номера карты")]
        public long CardNumber { get; set; }
        [Column("balance")]
        [Range(0,100000000, ErrorMessage = "Баланс должен быть положительным")]
        [Required(ErrorMessage = "Введите пополяемый баланс")]
        public double Balance { get; set; }
        [Column("pin")]
        public string PinCode { get; set; }
        [Column("attempts")]
        public int Attempts { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        [Column("finish_date")]
        [Required(ErrorMessage = "Срок окончания обязателен")]
        public DateTime FinishDate { get; set; }
        [NotMapped]
        [Range(1000, 9999, ErrorMessage = "Пин должен быть четырёхзначным")]
        [Required(ErrorMessage = "Пин обязателен")]
        public int Pin { get; set; }
    }
}
