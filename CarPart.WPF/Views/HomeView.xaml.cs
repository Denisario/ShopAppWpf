﻿using System;
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
        public HomeView()
        {
            DataContext = App.service.GetRequiredService<ICarPartViewModelFactory<HomeViewModel>>().CreateViewModel();
            InitializeComponent();
        }

        private void BalanceBtn_OnClick(object sender, RoutedEventArgs e)
        {
            AddBalanceView v=new AddBalanceView();
            v.Show();
        }
    }
}
