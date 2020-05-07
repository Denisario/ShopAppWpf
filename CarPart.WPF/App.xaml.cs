using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CarPart.WPF.State.Authentificators;
using CarPart.WPF.State.Navigators;
using CarPart.WPF.ViewModels;
using CarPart.WPF.ViewModels.Factories;
using CarPart.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using PartShop.Domain.Model;
using PartShop.Domain.Services;
using PartShop.EntityFramework;
using PartShop.EntityFramework.Services;

namespace CarPart.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider service;
        protected override void OnStartup(StartupEventArgs e)
        { 
            service = CreateServiceProvider();

            Window window = service.GetRequiredService<MainWindow>();

            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection service=new ServiceCollection();
            service.AddSingleton<INavigator, Navigator>();
            service.AddScoped<MainViewModel>();
            service.AddSingleton<MainWindow>(s=>new MainWindow(s.GetRequiredService<MainViewModel>()));
            //service.AddSingleton<HomeView>(s=>new HomeView(s.GetRequiredService<HomeViewModel>()));
            service.AddSingleton<IAuthentificator, Authentificator>();

            service.AddSingleton<CarPartDbContextFactory>();
            service.AddSingleton<IAuthentificationService, AuthentificationService>();
            service.AddSingleton<IDataService<Account>, AccountDataService>();
            service.AddSingleton<IAccountService, AccountDataService>();
            service.AddSingleton<ICarPartViewModelAbstractFactory, CarPartViewModelAbstractFactory>();
            service.AddSingleton<ICarPartViewModelFactory<AuthViewModel>, AuthViewModelFactory>();
            service.AddSingleton<ICarPartViewModelFactory<RegisterViewModel>, RegisterViewModelFactory>();
            service.AddSingleton<ICarPartViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            service.AddSingleton<ICarPartViewModelFactory<PartViewModel>, PartViewModelFactory>();
            return service.BuildServiceProvider();
        }
    }
}
