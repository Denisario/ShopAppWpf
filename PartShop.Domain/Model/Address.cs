using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("Address")]
    public class Address:DomainObject
    {
        [ForeignKey("Order")]
        [Column("id")]
        public override int Id { get; set; }
        [Required(ErrorMessage = "Город обязателен")]
        [Column("city")]
        public string City { get; set; }
        [Column("street")]
        [Required(ErrorMessage = "Улица обязателен")]
        public string Street { get; set; }
        [Column("house_number")]
        [Required(ErrorMessage = "Номер дома обязателен")]
        [Range(1, 100000, ErrorMessage = "Номер дома не может быть отрицательным")]
        public int House { get; set; }
        [Column("apartament_number")]
        [Range(1, 100000, ErrorMessage = "Номер квартиры не может быть отрицательным")]
        public int? Apartament { get; set; }
        public Order Order { get; set; }


        public override string ToString()
        {
            return $"{City} city, {Street} str, {House}-{Apartament}";
        }
    }
}
