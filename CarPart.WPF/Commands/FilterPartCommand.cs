using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;

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
            if (_partViewModel.Article < 0)
            {
                MessageBox.Show("Отрицательный артикул недопустим");
                return;
            }

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

            if (_partViewModel.Article != 0)
            {
                _partViewModel.Parts = _partViewModel.Parts.Where(p => p.PartArticle == _partViewModel.Article).ToList();
            }

            if (_partViewModel.Category != null)
            {
                _partViewModel.Parts = _partViewModel.Parts.Where(p => p.PartCategory == _partViewModel.Category).ToList();
            }

            if (_partViewModel.Name != null)
            {
                _partViewModel.Parts = _partViewModel.Parts.Where(p => p.PartName.StartsWith(_partViewModel.Name)).ToList();
            }

        }

        public event EventHandler CanExecuteChanged;
    }
}
