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
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider service = CreateServiceProvider();

            
            Window window = service.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
            

        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection service=new ServiceCollection();
            service.AddScoped<INavigator, Navigator>();
            service.AddScoped<MainViewModel>();
            service.AddScoped<MainWindow>(s=>new MainWindow(s.GetRequiredService<MainViewModel>()));
            service.AddScoped<IAuthentificator, Authentificator>();

            service.AddSingleton<CarPartDbContextFactory>();
            service.AddSingleton<IAuthentificationService, AuthentificationService>();
            service.AddSingleton<IDataService<Account>, AccountDataService>();
            service.AddSingleton<IAccountService, AccountDataService>();
            service.AddSingleton<ICarPartViewModelAbstractFactory, CarPartViewModelAbstractFactory>();
            service.AddSingleton<ICarPartViewModelFactory<AuthViewModel>, AuthViewModelFactory>();
            service.AddSingleton<ICarPartViewModelFactory<RegisterViewModel>, RegisterViewModelFactory>();
            return service.BuildServiceProvider();
        }
    }
}
