using System;
using System.Collections.Generic;
using System.Text;
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

        public void Execute(object parameter)
        {
            _cardService.Withdraw(_authentificator.CurrentAccount, _addBalanceViewModel.Number,
                _addBalanceViewModel.Pin, _addBalanceViewModel.FinishDate, _addBalanceViewModel.Money);
        }

        public event EventHandler CanExecuteChanged;
    }
}
