using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarPart.WPF.Commands;
using CarPart.WPF.State.Authentificators;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace CarPart.WPF.ViewModels
{
    public class CartViewModel:ViewModelBase
    {
        private readonly IAuthentificator _authentificator;
        private readonly ICartService _cartService;

        public ICommand DeletePartCommand { get; set; }
        public CartViewModel(IAuthentificator authentificator, ICartService cartService)
        {
            _authentificator = authentificator;
            _cartService = cartService;
            DeletePartCommand=new DeletePartFromCartCommand(this,_cartService, _authentificator);
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

        private PartFullInfo selectedPart;

        public PartFullInfo SelectedPart
        {
            get => selectedPart;
            set
            {
                selectedPart = value;
                OnPropertyChanged(nameof(SelectedPart));
            }
        }

        public async void GetAllPartsInCart()
        {
            PartInCart= new ObservableCollection<PartFullInfo>(await _cartService.GetAllPartsInView(_authentificator.CurrentAccount));
        }
    }
}
