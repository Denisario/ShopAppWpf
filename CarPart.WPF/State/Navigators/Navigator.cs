﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using CarPart.WPF.Annotations;
using CarPart.WPF.Commands;
using CarPart.WPF.ViewModels;
using CarPart.WPF.ViewModels.Factories;

namespace CarPart.WPF.State.Navigators
{
    public class Navigator:INavigator, INotifyPropertyChanged
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel=value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public ICommand UpdateCurrentViewModelCommand { get; set; }
    

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Navigator(ICarPartViewModelAbstractFactory viewModelFactory)
        {
            UpdateCurrentViewModelCommand=new UpdateCurrentViewModelCommand(this, viewModelFactory);
        }
    }
}
