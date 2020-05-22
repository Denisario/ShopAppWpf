using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CarPart.WPF.ViewModels;
using Microsoft.Win32;
using PartShop.Domain.Services;

namespace CarPart.WPF.Commands
{
    public class GetCheckCommand:ICommand
    {
        private readonly IOrderService _orderService;
        private readonly HomeViewModel _homeViewModel;
        private readonly OrderViewModel _orderViewModel;
        public GetCheckCommand(IOrderService orderService, HomeViewModel homeViewModel)
        {
            _orderService = orderService;
            _homeViewModel = homeViewModel;
        }


        public GetCheckCommand(IOrderService orderService, OrderViewModel orderViewModel)
        {
            _orderService = orderService;
            _orderViewModel = orderViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try { 
                SaveFileDialog saveFileDialog=new SaveFileDialog();
                saveFileDialog.Filter= "Pdf-files(*.pdf)|*.pdf";
                saveFileDialog.ShowDialog();

                string path = saveFileDialog.FileName;  
                if (_homeViewModel == null)
                {
                    await _orderService.PrintCheck(_orderViewModel.SelectedOrder, path);
                }

                if (_orderViewModel == null)
                {
                    await _orderService.PrintCheck(_homeViewModel.SelectedOrder, path);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
