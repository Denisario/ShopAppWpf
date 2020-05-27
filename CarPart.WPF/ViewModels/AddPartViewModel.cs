using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class AddPartViewModel:ViewModelBase
    {
        private readonly IProviderService _providerService;
        private readonly ICarService _carService;
        private readonly IPartService _partService;

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

        private ObservableCollection<Car> cars;

        public ObservableCollection<Car> Cars
        {
            get => cars;
            set
            {
                cars = value;
                OnPropertyChanged(nameof(Cars));
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

        private string color;

        public string Color
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        private string description;

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
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

        private Car car;

        public Car Car
        {
            get => car;
            set
            {
                car = value;
                OnPropertyChanged(nameof(Car));
            }
        }

        private double price;

        public double Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private int amount;

        public int Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
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

        private string selectedCategory;

        public String SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
        public ICommand AddPartCommand { get; set; }
        public AddPartViewModel(IProviderService providerService, ICarService carService, IPartService partService)
        {
            AddPartCommand=new AddPartCommand(partService, this);
            _providerService = providerService;
            _carService = carService;
            GetListOfProviders();
            GetListOfCars();
        }

        private async void GetListOfProviders()
        {
            Providers = new ObservableCollection<Provider>(new List<Provider>(await _providerService.GetAll()));
        }

        private async void GetListOfCars()
        {
            Cars=new ObservableCollection<Car>(new List<Car>(await _carService.GetAll()));
        }
    }
}
