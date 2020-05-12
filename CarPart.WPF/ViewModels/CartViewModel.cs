using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class CartViewModel:ViewModelBase
    {
        private readonly IAuthentificator _authentificator;
        private readonly ICartService _cartService;

        public CartViewModel(IAuthentificator authentificator, ICartService cartService)
        {
            _authentificator = authentificator;
            _cartService = cartService;
            GetAllPartsInCart();
        }

        private ObservableCollection<PartFullInfo> partInCart;


        public ObservableCollection<PartFullInfo> PartInCart
        {
            get
            {
                return partInCart;
            }
            set
            {
                partInCart = value;
                OnPropertyChanged(nameof(PartInCart));
            }
        }

        public async void GetAllPartsInCart()
        {
            PartInCart= new ObservableCollection<PartFullInfo>(await _cartService.GetAllPartsInView(_authentificator.CurrentAccount));
        }
    }
}
