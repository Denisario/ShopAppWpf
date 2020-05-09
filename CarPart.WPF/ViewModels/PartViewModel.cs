using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class PartViewModel : ViewModelBase
    {
        private readonly IPartService _partService;

        public PartViewModel(IPartService partService)
        {
            _partService = partService;
            GetAllParts();
        }

        //private BindingList<Part> parts;

        //public BindingList<Part> Parts
        //{
        //    get => parts;
        //    set
        //    {
        //        parts = value;
        //        OnPropertyChanged(nameof(Parts));
        //    }
        //}

        private List<Part> parts;

        public List<Part> Parts
        {
            get => parts;
            set
            {
                parts = value;
                OnPropertyChanged(nameof(Parts));
            }
        }

        private int length;

        public int Length
        {
            get => length;
            set
            {
                length = value;
                OnPropertyChanged(nameof(length));
            }
        }

        private async void GetAllParts()
        {
            Parts = new List<Part>(await _partService.GetAll());
            Length = Parts[3].Id;
        }
    }
}
