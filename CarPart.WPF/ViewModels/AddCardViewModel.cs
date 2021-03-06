﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Commands;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class AddCardViewModel:ViewModelBase
    {
        private readonly ICardService _cardService;
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

        public ICommand AddCardCommand { get; set; }

        public AddCardViewModel(ICardService cardService)
        {

            _cardService = cardService;
            GetNumberOfCard();
            AddCardCommand = new AddCardCommand(this, cardService);
            FinishDate=DateTime.Now;
        }



        private async void GetNumberOfCard()
        {
            Number=await _cardService.GetNumberOfCard();
        }
    }
}
