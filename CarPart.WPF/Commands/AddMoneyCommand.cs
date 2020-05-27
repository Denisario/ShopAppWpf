using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.ViewModels;
using CarPart.WPF.Views;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    public class AddMoneyCommand:ICommand
    {
        private readonly ICardService _cardService;
        private readonly IAuthentificator _authentificator;
        private readonly AddBalanceViewModel _addBalanceViewModel;
        public event EventHandler CanExecuteChanged;

        public AddMoneyCommand(ICardService cardService, IAuthentificator authentificator, AddBalanceViewModel addBalanceViewModel)
        {
            _cardService = cardService;
            _authentificator = authentificator;
            _addBalanceViewModel = addBalanceViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
               await _cardService.Withdraw(_authentificator.CurrentAccount, new Card()
                {
                    CardNumber = _addBalanceViewModel.Number,
                    Pin = _addBalanceViewModel.Pin,
                    FinishDate = _addBalanceViewModel.FinishDate,
                    Balance = _addBalanceViewModel.Money
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
