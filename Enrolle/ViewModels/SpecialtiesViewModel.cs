using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        public SpecialtiesViewModel(IRepository<Specialization> repository, BusyStore busyStore) : base(repository, busyStore)
        {
        }

        public static SpecialtiesViewModel BuildAndLoad(IServiceProvider serviceProvider)
        {
            SpecialtiesViewModel specialtiesViewModel = new SpecialtiesViewModel(
                    serviceProvider.GetRequiredService<IRepository<Specialization>>(),
                    serviceProvider.GetRequiredService<BusyStore>()
            );

            specialtiesViewModel.InitializeCollectionCommand.Execute(null);

            return specialtiesViewModel;
        }

        protected override Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
