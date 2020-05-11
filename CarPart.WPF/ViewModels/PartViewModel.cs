using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using Microsoft.EntityFrameworkCore.Internal;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class PartViewModel : ViewModelBase
    {
        private readonly IPartService _partService;
        private readonly ICarService _carService;
        private readonly IProviderService _providerService;

        public ICommand FilterPartCommand { get; set; }
        public PartViewModel(IPartService partService, ICarService carService, IProviderService providerService)
        {
            _partService = partService;
            _carService = carService;
            _providerService = providerService;
            FilterPartCommand=new FilterPartCommand(this);
            GetAllParts();
            GetAllMarks();
            GetListOfProviders();
        }

        private string mark;

        public string Mark
        {
            get
            {
                GetAllModels(mark); return mark;
            }
            set
            {
                mark = value;
                OnPropertyChanged(nameof(Mark));
            }
        }

        private string model;

        public string Model
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged(nameof(Model));
                
            }
        }

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

        private List<string> marks;
        public List<string> Marks
        {
            get => marks;
            set
            {
                marks = value;
                OnPropertyChanged(nameof(Marks));
            }
        }

        private List<string> models;

        public List<string> Models
        {
            get => models;
            set
            {
                models = value;
                OnPropertyChanged(nameof(Models));
            }
        }

        private List<Provider> providers;
        public List<Provider> Providers
        {
            get { return providers; }
            set
            {
                providers = value;
                OnPropertyChanged(nameof(Providers));
            }
        }

        private Provider partProvider;

        public Provider PartProvider
        {
            get => partProvider;
            set
            {
                partProvider = value;
                OnPropertyChanged(nameof(PartProvider));
            }
        }

        private async void GetAllParts()
        {
            Parts = new List<PartFullInfo>(await _partService.GetAllPartsForView());
        }

        private async void GetAllMarks()
        {
            Marks=new List<string>(await _carService.GetAllMarks());
        }

        private async void GetAllModels(string mark)
        {
            Models = new List<string>(await _carService.GetAllModels(mark));
        }

        private async void GetListOfProviders()
        {
            Providers = new List<Provider>(await _providerService.GetAll());
        }
    }
}
