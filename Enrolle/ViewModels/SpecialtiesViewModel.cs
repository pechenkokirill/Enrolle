using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.ViewModels
{
    public class SpecialtiesViewModel : TableEditBaseViewModel<Specialization>
    {
        public SpecialtiesViewModel(IRepository<Specialization> repository) : base(repository)
        {
        }
    }
}
