﻿using System;
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
using PartShop.Domain.Services;
using PartShop.Domain.Services.Impl;
using PartShop.EntityFramework;
using PartShop.EntityFramework.Service;

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

            AuthService authService = new AuthService(
                new GenericDataService<Role>(new CarPartDbContextFactory()),
                new GenericDataService<User>(new CarPartDbContextFactory())
            );

            bool account = authService.Register("ddsadsaas", "fdsfl", "lfsfda", "das").Result;
            Console.WriteLine(account);

            base.OnStartup(e);
        }
    }
}
