using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework.Services;

namespace CarPart.WPF.Commands
{
    public class AddCarCommand:ICommand
    {
        private readonly ICarService _carDataService;
        private AddCarViewModel _carViewModel;

        public AddCarCommand(ICarService carDataService, AddCarViewModel carViewModel)
        {
            _carDataService = carDataService;
            _carViewModel = carViewModel;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                await _carDataService.Create(new Car()
                {
                    CreationYear = _carViewModel.Year,
                    FuelType = _carViewModel.FuelType,
                    Mark = _carViewModel.Mark,
                    Model = _carViewModel.Model
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        
    }
}
