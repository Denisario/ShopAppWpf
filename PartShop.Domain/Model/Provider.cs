using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("Providers")]
    public class Provider:DomainObject
    {
        [Key]
        [Column("id")]
        public override int Id { get; set; }
        [Column("name")]
        [Required(ErrorMessage = "Имя поставщика обязательно")]
        public string Name { get; set; }
        public List<PartProvider> PartProviders { get; set; }
    }
}
