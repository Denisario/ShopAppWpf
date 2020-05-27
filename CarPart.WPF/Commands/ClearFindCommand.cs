using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    public class ClearFindCommand:ICommand
    {
        private readonly IPartService _partService;
        private readonly PartViewModel _partViewModel;
        public ClearFindCommand(IPartService partService, PartViewModel partViewModel)
        {
            _partService = partService;
            _partViewModel = partViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)=>_partViewModel.Parts=new ObservableCollection<PartFullInfo>(await _partService.GetAllPartsForView());

    }
}
