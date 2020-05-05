using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CarPart.WPF.State.Navigators;
using CarPart.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using PartShop.Domain.Model;
using PartShop.EntityFramework;

namespace CarPart.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }
}
