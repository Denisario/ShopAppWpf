using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    public class AddProviderCommand : ICommand
    {
        private readonly IProviderService _providerDataService;
        private AddProviderViewModel _addProvideriewModel;
        public event EventHandler CanExecuteChanged;

        public AddProviderCommand(IProviderService providerDataService, AddProviderViewModel addProvideriewModel)
        {
            _providerDataService = providerDataService;
            _addProvideriewModel = addProvideriewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                await _providerDataService.Create(new Provider()
                {
                    Name = _addProvideriewModel.Name
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        
    }
}
