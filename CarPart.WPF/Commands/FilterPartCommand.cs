using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.ViewModels;

namespace CarPart.WPF.Commands
{
    public class FilterPartCommand:ICommand
    {
        private readonly PartViewModel _partViewModel;

        public FilterPartCommand(PartViewModel partViewModel)
        {
            _partViewModel = partViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_partViewModel.Mark != null)
            {
                _partViewModel.Parts = _partViewModel.Parts.Where(p => p.CarMark == _partViewModel.Mark).ToList();
            }

            if (_partViewModel.Model != null)
            {
                _partViewModel.Parts = _partViewModel.Parts.Where(p => p.CarModel == _partViewModel.Model).ToList();
            }

            if (_partViewModel.PartProvider != null)
            {
                _partViewModel.Parts = _partViewModel.Parts.Where(p => p.ProviderName == _partViewModel.PartProvider.Name).ToList();
            }

        }

        public event EventHandler CanExecuteChanged;
    }
}
