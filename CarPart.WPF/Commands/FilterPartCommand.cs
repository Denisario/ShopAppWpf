using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;
using PartShop.Domain.Model;

namespace CarPart.WPF.Commands
{
    public class FilterPartCommand:ICommand
    {
        private readonly PartViewModel _partViewModel;
        public event EventHandler CanExecuteChanged;

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
                _partViewModel.Parts = new ObservableCollection<PartFullInfo>(_partViewModel.Parts.Where(p => p.CarMark == _partViewModel.Mark).ToList().OrderBy(x=>x.CarMark));
            }

            if (_partViewModel.Model != null)
            {
                _partViewModel.Parts = new ObservableCollection<PartFullInfo>(_partViewModel.Parts.Where(p => p.CarModel == _partViewModel.Model).ToList().OrderBy(x=>x.CarModel));
            }

            if (_partViewModel.PartProvider != null)
            {
                _partViewModel.Parts = new ObservableCollection<PartFullInfo>(_partViewModel.Parts.Where(p => p.ProviderName == _partViewModel.PartProvider.Name).ToList());
            }

            if (_partViewModel.Article != 0)
            {
                _partViewModel.Parts = new ObservableCollection<PartFullInfo>(_partViewModel.Parts.Where(p => p.PartArticle == _partViewModel.Article).ToList());
            }

            if (_partViewModel.Category != null)
            {
                _partViewModel.Parts = new ObservableCollection<PartFullInfo>(_partViewModel.Parts.Where(p => p.PartCategory == _partViewModel.Category).ToList());
            }

            if (_partViewModel.Name != null)
            {
                _partViewModel.Parts = new ObservableCollection<PartFullInfo>(_partViewModel.Parts.Where(p => p.PartName.StartsWith(_partViewModel.Name)).ToList());
            }

        }

    }
}
