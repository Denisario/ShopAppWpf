using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    class AddCardCommand:ICommand
    {
        private readonly ICardService _cardService;
        private readonly AddCardViewModel _addCardViewModel;

        public AddCardCommand(AddCardViewModel addCardViewModel, ICardService cardService)
        {
            _addCardViewModel = addCardViewModel;
            _cardService = cardService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                await _cardService.CreateCard(_addCardViewModel.Pin, _addCardViewModel.FinishDate);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
