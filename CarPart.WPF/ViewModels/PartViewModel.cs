using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PartShop.Domain.Model;

namespace CarPart.WPF.ViewModels
{
    public class PartViewModel:ViewModelBase
    {
        private ObservableCollection<Part> _parts;

        public ObservableCollection<Part> Parts { get; set; }
    }
}
