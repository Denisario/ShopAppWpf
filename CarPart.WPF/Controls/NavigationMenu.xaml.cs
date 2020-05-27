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
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CarPart.WPF.Controls
{
    /// <summary>
    /// Логика взаимодействия для NavigationMenu.xaml
    /// </summary>
    public partial class NavigationMenu : UserControl
    {
        public NavigationMenu()
        {
            InitializeComponent();
        }

        private void ButtonCloseMenu_OnClick(object sender, RoutedEventArgs e)
        {
            UserData.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            
        }

        private void ButtonOpenMenu_OnClick(object sender, RoutedEventArgs e)
        {
            UserData.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }
    }
}
