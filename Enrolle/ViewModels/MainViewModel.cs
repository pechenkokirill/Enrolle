using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Enrolle.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly INavigation navigation;
        private readonly BusyStore busyStore;

        public ObservableObject? CurrentPage { get; private set; }
        public RelayCommand GoToMainCommand { get; set; }
        public bool IsBusy => busyStore.IsBusy;

        public MainViewModel(INavigation navigation, BusyStore busyStore)
        {
            this.navigation = navigation;
            this.busyStore = busyStore;
            busyStore.OnBusyChanged += () => OnPropertyChanged("IsBusy");
            navigation.Navigated += Navigation_Navigated;
            navigation.Navigate(typeof(MainPageViewModel));
            GoToMainCommand = new RelayCommand(GoToMain, () => !IsBusy);
        }

        private void Navigation_Navigated(ObservableObject? vm)
        {
            CurrentPage = vm;
        }

        private void GoToMain()
        {
            navigation.Navigate(typeof(MainPageViewModel));
        }
    }
}
