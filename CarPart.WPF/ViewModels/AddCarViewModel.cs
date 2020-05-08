using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class AddCarViewModel:ViewModelBase
    {
        //private readonly IDataService<Car> _carService;
        private string mark;

        public string Mark
        {
            get => mark;
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

        private int year;

        public int Year
        {
            get => year;
            set
            {
                year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        private string fuelType;

        public AddCarViewModel(ICarService carService)
        {
            AddCarCommand = new AddCarCommand(carService,this);
        }

        public string FuelType
        {
            get => fuelType;
            set
            {
                fuelType = value;
                OnPropertyChanged(nameof(FuelType));
            }
        }

        public ICommand AddCarCommand { get; set; }
    }
}
