using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class AddProviderViewModel:ViewModelBase
    {
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

        public ICommand AddProviderCommand { get; set; }

        public AddProviderViewModel(IProviderService providerService)
        {
            AddProviderCommand=new AddProviderCommand(providerService, this);
        }
    }
}
