using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CarPart.WPF.ViewModels;
using CarPart.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using PartShop.Domain.Services;

namespace CarPart.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AddCardView.xaml
    /// </summary>
    public partial class AddCardView : Window
    {
        public AddCardView()
        {
            InitializeComponent();
            DataContext = App.service.GetRequiredService<ICarPartViewModelFactory<AddCardViewModel>>()
                .CreateViewModel();
        }

        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
