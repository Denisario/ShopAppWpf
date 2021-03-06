﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
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
        public event EventHandler CanExecuteChanged;
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

            try
            {
                if (_addPartViewModel.PartProvider == null)
                {
                    MessageBox.Show("Не выбран поставщик");
                    return;
                }

                if (_addPartViewModel.Car == null)
                {
                    MessageBox.Show("Не выбрана машина");
                    return;
                }

                bool success = await _partService.AddPart(
                    new Part()
                    {
                        Color = _addPartViewModel.Color, 
                        Description = _addPartViewModel.Description,
                        Name = _addPartViewModel.Name,
                        Article = _addPartViewModel.Article,
                        Category = _addPartViewModel.SelectedCategory
                    },
                    _addPartViewModel.PartProvider.Id, _addPartViewModel.Car.Id, _addPartViewModel.Amount,
                    _addPartViewModel.Price
                );
                if (success == false) MessageBox.Show("Данная деталь уже существует.\n Данные по наличию и цене были обновлены");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


    }
}
