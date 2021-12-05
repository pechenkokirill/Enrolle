using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.ViewModels
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly INavigation navigation;

        public MainPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;

            GoToTablesCommand = new RelayCommand(GoToTables);
        }

        private void GoToTables()
        {
            navigation.Navigate(typeof(TablesChooseViewModel));
        }

        public RelayCommand GoToTablesCommand { get; set; }
    }
}
