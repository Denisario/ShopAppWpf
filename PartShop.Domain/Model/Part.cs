using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("Parts")]
    public class Part:DomainObject
    {
        [Column("id")]
        public override int Id { get; set; }
        [Column("name")]
        [Required(ErrorMessage = "Наименование запчасти обязательно")]
        public string Name { get; set; }
        [Column("category")]
        [Required(ErrorMessage = "Катергория обязательна")]
        public string Category { get; set; }
        [Column("article")]
        [Required(ErrorMessage = "Артикул")]
        public int Article { get; set; }
        [Column("description")]
        [Required(ErrorMessage = "Описание обязательно")]
        public string Description { get; set; }
        [Column("color")]
        [Required(ErrorMessage = "Цвет обязателен")]
        public string Color { get; set; }
        public List<CarPart> CarParts { get; set; }
        public List<PartProvider> PartProviders { get; set; }

        public Part()
        {
            PartProviders=new List<PartProvider>();
            CarParts=new List<CarPart>();
        }
    }
}
