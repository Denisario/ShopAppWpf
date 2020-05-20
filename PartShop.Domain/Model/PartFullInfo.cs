using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class PartFullInfo {
        public bool IsSelected { get; set; }
        public int PartId { get; set; }
        public int PartArticle { get; set; }
        public string PartCategory { get; set; }
        public int ProviderId { get; set; }
        public int CarId { get; set; }
        public string PartName { get; set; }
        public string PartColor { get; set; }
        public string PartDescription { get; set; }
        public string ProviderName { get; set; }
        public int ProviderPartAmount { get; set; }
        public double ProviderPartPrice { get; set; }
        public string CarMark { get; set; }
        public string CarModel { get; set; }
        public string CarFuelType { get; set; }
        public int CarCreationYear { get; set; }
    }
}
