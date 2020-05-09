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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarPart.WPF.ViewModels;
using CarPart.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CarPart.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для PartView.xaml
    /// </summary>
    public partial class PartView : UserControl
    {
        public PartView()
        {
            DataContext = App.service.GetRequiredService<ICarPartViewModelFactory<PartViewModel>>().CreateViewModel();
            InitializeComponent();
        }
    }
}
