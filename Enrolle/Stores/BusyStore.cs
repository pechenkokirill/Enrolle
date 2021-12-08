using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Stores
{
    public class BusyStore : IDisposable
    {
        private bool isBusy;

        public bool IsBusy { get { return isBusy; } set { isBusy = value; OnBusyChanged?.Invoke(); } }

        public event Action? OnBusyChanged;

        public BusyStore SetBusy()
        {
            IsBusy = true;
            return this;
        }

        public void Dispose()
        {
            IsBusy = false;
        }
    }
}
