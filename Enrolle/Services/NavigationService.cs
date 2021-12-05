using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Enrolle.Services
{
    public class NavigationService : INavigation
    {
        private readonly IServiceProvider serviceProvider;
        public NavigationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public event Action<ObservableObject?>? Navigated;

        public void Navigate(Type view)
        {
            Navigated?.Invoke(serviceProvider.GetService(view) as ObservableObject);
        }
    }
}
