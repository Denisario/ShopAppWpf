using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class AddBalanceViewModel:ViewModelBase
    {
        private long number;
        public long Number
        {
            get => number;
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        private int pin;
        public int Pin
        {
            get => pin;
            set
            {
                pin = value;
                OnPropertyChanged(nameof(Pin));
            }
        }

        private DateTime finishDate;
        public DateTime FinishDate
        {
            get => finishDate;
            set
            {
                finishDate = value;
                OnPropertyChanged(nameof(FinishDate));
            }
        }

        private double money;
        public double Money
        {
            get => money;
            set
            {
                money = value;
                OnPropertyChanged(nameof(Money));
            }
        }
        public ICommand AddBalanceCommand { get; set; }

        public AddBalanceViewModel(ICardService cardService, IAuthentificator authentificator)
        {
            FinishDate=DateTime.Now;
            AddBalanceCommand = new AddMoneyCommand(cardService, authentificator, this);
        }
        
    }
}
