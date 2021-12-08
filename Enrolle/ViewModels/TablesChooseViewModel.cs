using Enrolle.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.ViewModels
{
    public class TablesChooseViewModel : ObservableObject
    {
        private readonly INavigation navigation;
        public RelayCommand<Type> GoToCommand { get; set; }
        public TablesChooseViewModel(INavigation navigation)
        {
            GoToCommand = new RelayCommand<Type>(GoTo);
            this.navigation = navigation;
        }

        private void GoTo(Type? type)
        {
            navigation.Navigate(type!);
        }
    }
}
