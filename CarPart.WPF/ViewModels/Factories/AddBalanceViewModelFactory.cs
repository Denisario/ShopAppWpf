using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    public class AddBalanceViewModelFactory:ICarPartViewModelFactory<AddBalanceViewModel>
    {
        private readonly ICardService _cardService;
        private readonly IAuthentificator _authentificator;
        public AddBalanceViewModelFactory(ICardService cardService, IAuthentificator authentificator)
        {
            _authentificator = authentificator;
            _cardService = cardService;
        }

        public AddBalanceViewModel CreateViewModel()
        {
            return new AddBalanceViewModel(_cardService,_authentificator);
        }
    }
}
