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

namespace CarPart.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AddPartView.xaml
    /// </summary>
    public partial class AddPartView : Window
    {
        public AddPartView()
        {
            DataContext = App.service.GetRequiredService<ICarPartViewModelFactory<AddPartViewModel>>().CreateViewModel();
            InitializeComponent();
        }
    }
}
