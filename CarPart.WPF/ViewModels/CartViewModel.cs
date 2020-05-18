﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public ICommand CreateOrderCommand { get; set; }
        public CartViewModel(IAuthentificator authentificator, ICartService cartService, IOrderService orderService)
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
                foreach (var p in PartInCart)
                {
                    if (p.Equals(selectedPart))
                    {
                        p.IsSelected = true;
                        OnPropertyChanged(nameof(SelectedPart));
                        OnPropertyChanged(nameof(SelectedPart.IsSelected));
                        OnPropertyChanged(nameof(PartInCart));
                        _authentificator.Parts = new List<PartFullInfo>(PartInCart);
                        break;
                    }
                }
                
            }
        }


        

        public async void GetAllPartsInCart()
        {
            PartInCart= new ObservableCollection<PartFullInfo>(await _cartService.GetAllPartsInView(_authentificator.CurrentAccount));
        }
    }
}
