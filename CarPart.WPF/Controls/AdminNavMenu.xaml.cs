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
using CarPart.WPF.Views;

namespace CarPart.WPF.Controls
{
    /// <summary>
    /// Логика взаимодействия для AdminNavMenu.xaml
    /// </summary>
    public partial class AdminNavMenu : UserControl
    {
        public AdminNavMenu()
        {
            InitializeComponent();
        }

        private void AddCarBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddCarView v = new AddCarView();
            v.Show();
        }

        private void AddProvBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddProviderView v=new AddProviderView();
            v.Show();
        }

        private void AppPartBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddPartView d=new AddPartView();
            d.Show();
        }
    }
}
