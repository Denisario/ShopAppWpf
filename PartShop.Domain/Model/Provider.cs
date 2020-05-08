using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Provider:DomainObject
    {
        [Key]
        public override int Id { get; set; }
        public string Name { get; set; }
        public List<PartProvider> PartProviders { get; set; }
    }
}
