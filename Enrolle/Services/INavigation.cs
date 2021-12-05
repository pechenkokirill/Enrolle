using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Enrolle.Services
{
    public interface INavigation
    {
        event Action<ObservableObject?>? Navigated;
        void Navigate(Type view);
    }
}
