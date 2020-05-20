using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("Cars")]
    public class Car:DomainObject
    {
        [Key]
        [Column("id")]
        public override int Id { get; set; }
        [Required(ErrorMessage = "Марка обязательна")]
        [Column("mark")]
        public string Mark { get; set; }
        [Required(ErrorMessage = "Модель обязательна")]
        [Column("model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Тип топлива обязателен")]
        [Column("fuel_type")]
        public string FuelType { get; set; }
        [Column("creation_year")]
        [Range(1950, 2020, ErrorMessage = "Год выпуска должен быть с 1950 до 2020")]
        [Required(ErrorMessage = "Год выпуска обязателен")]
        public int CreationYear { get; set; }
        public List<CarPart> CarParts { get; set; }
    }
}
