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
using CarPart.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CarPart.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        //public static readonly DependencyProperty AuthProperty =
        //    DependencyProperty.Register("AuthAuthentificator", typeof(IAuthentificator), typeof(HomeView), new PropertyMetadata(null));

        //public IAuthentificator AuthAuthentificator
        //{
        //    get { return (IAuthentificator)GetValue(AuthProperty); }
        //    set { SetValue(AuthProperty, value); }
        //

        public HomeView()
        {
            DataContext = App.service.GetRequiredService<ICarPartViewModelFactory<HomeViewModel>>().CreateViewModel();
            //DataContext = App.service.GetRequiredService<ICarPartViewModelFactory<PartViewModel>>();
            InitializeComponent();
        }
    }
}
