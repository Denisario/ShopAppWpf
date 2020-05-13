using System;
using System.Collections.Generic;
using System.Text;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels.Factories
{
    public class AddCardViewModelFactory:ICarPartViewModelFactory<AddCardViewModel>
    {
        private readonly ICardService _cardService;

        public AddCardViewModelFactory(ICardService cardService)
        {
            _cardService = cardService;
        }

        public AddCardViewModel CreateViewModel()
        {
            return new AddCardViewModel(_cardService);
        }
    }
}
