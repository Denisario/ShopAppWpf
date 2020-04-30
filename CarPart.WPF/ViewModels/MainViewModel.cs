using System;
using System.Collections.Generic;
using System.Text;
using CarPart.WPF.State.Navigators;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarPart.WPF.ViewModels
{
    class MainViewModel:ViewModelBase
    {
        public INavigator Navigator { get; set; }=new Navigator();
    }
}
