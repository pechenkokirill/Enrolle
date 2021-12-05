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

        public ObservableObject? CurrentPage { get; private set; }
        public RelayCommand GoToMainCommand { get; set; }


        public MainViewModel(INavigation navigation)
        {
            this.navigation = navigation;

            navigation.Navigated += Navigation_Navigated;

            navigation.Navigate(typeof(MainPageViewModel));

            GoToMainCommand = new RelayCommand(GoToMain);
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
