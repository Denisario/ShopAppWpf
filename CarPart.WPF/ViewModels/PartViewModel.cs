using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
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

        private List<PartFullInfo> parts;

        public List<PartFullInfo> Parts
        {
            get => parts;
            set
            {
                parts = value;
                OnPropertyChanged(nameof(Parts));
            }
        }

        private async void GetAllParts()
        {
            Parts = new List<PartFullInfo>(await _partService.GetAllPartsForView());

        }
    }
}
