using Microsoft.Toolkit.Mvvm.ComponentModel;
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
        public ObservableObject? CurrentPage { get; private set; }

        public MainViewModel(INavigation navigation)
        {
            navigation.Navigated += Navigation_Navigated;

            navigation.Navigate(typeof(MainPageViewModel));
        }

        private void Navigation_Navigated(ObservableObject? vm)
        {
            CurrentPage = vm;
        }
    }
}
