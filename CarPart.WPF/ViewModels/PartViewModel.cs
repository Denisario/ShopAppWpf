using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using CarPart.WPF.State.Authentificators;
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
        private readonly IAuthentificator _authentificator;

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

        private ObservableCollection<PartFullInfo> parts;

        public ObservableCollection<PartFullInfo> Parts
        {
            get => parts;
            set
            {
                parts = value;
                OnPropertyChanged(nameof(Parts));
            }
        }

        private PartFullInfo part;
        public PartFullInfo Part
        {
            get => part;
            set
            {
                part = value;
                OnPropertyChanged(nameof(Part));
            }
        }

        private ObservableCollection<string> marks;
        public ObservableCollection<string> Marks
        {
            get => marks;
            set
            {
                marks = value;
                OnPropertyChanged(nameof(Marks));
            }
        }

        private ObservableCollection<string> models;

        public ObservableCollection<string> Models
        {
            get => models;
            set
            {
                models = value;
                OnPropertyChanged(nameof(Models));
            }
        }

        private ObservableCollection<Provider> providers;
        public ObservableCollection<Provider> Providers
        {
            get { return providers; }
            set
            {
                providers = value;
                OnPropertyChanged(nameof(Providers));
            }
        }


        private int article;
        public int Article
        {
            get => article;
            set
            {
                article = value;
                OnPropertyChanged(nameof(Article));
            }
        }

        private string category;

        public string Category
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
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

        public ICommand FilterPartCommand { get; set; }

        public ICommand AddPartToCartCommand { get; set; }

        public ICommand ClearFindCommand { get; set; }
        public PartViewModel(IPartService partService, ICarService carService, IProviderService providerService, ICartService cartService, IAuthentificator authentificator)
        {
            _partService = partService;
            _carService = carService;
            _providerService = providerService;
            _authentificator = authentificator;
            FilterPartCommand=new FilterPartCommand(this);
            AddPartToCartCommand=new AddPartToCartCommand(this,cartService, authentificator);
            ClearFindCommand=new ClearFindCommand(partService, this);
            GetAllParts();
            GetAllMarks();
            GetListOfProviders();
        }

        private async void GetAllParts()
        {
            Parts = new ObservableCollection<PartFullInfo>(new List<PartFullInfo>(await _partService.GetAllPartsForView()));
        }

        private async void GetAllMarks()
        {
            Marks=new ObservableCollection<string>(new List<string>(await _carService.GetAllMarks()));
        }

        private async void GetAllModels(string mark)
        {
            Models = new ObservableCollection<string>(new List<string>(await _carService.GetAllModels(mark)));
        }

        private async void GetListOfProviders()
        {
            Providers = new ObservableCollection<Provider>(new List<Provider>(await _providerService.GetAll()));
        }
    }
}
