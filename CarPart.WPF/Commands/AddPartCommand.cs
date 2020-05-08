using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using CarPart = PartShop.Domain.Model.CarPart;

namespace CarPart.WPF.Commands
{
    public class AddPartCommand:ICommand
    {
        private IPartService _partService;
        private readonly AddPartViewModel _addPartViewModel;

        public AddPartCommand(IPartService partService, AddPartViewModel addPartViewModel)
        {
            _partService = partService;
            _addPartViewModel = addPartViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Part part = new Part()
            {
                Color = _addPartViewModel.Color,
                Description = _addPartViewModel.Description,
                Name = _addPartViewModel.Name,
            };
            
            part.CarParts.Add(new PartShop.Domain.Model.CarPart()
            {
                PartId = part.Id, CarId = _addPartViewModel.Car.Id
            });

            part.PartProviders.Add(new PartProvider()
            {
                PartId = part.Id, ProviderId=_addPartViewModel.PartProvider.Id, TotalParts = _addPartViewModel.Amount, PartCost = _addPartViewModel.Price
            });
            await _partService.Create(part);
           // await _partService.Update(part.Id, part);

        }

        public event EventHandler CanExecuteChanged;
    }
}
