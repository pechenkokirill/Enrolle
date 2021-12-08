using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.ViewModels
{
    public class SubjectsViewModel : TableEditBaseViewModel<Subject>
    {
        public SubjectsViewModel(IRepository<Subject> repository, BusyStore busyStore) : base(repository, busyStore)
        {
        }

        public static SubjectsViewModel BuildAndLoad(IServiceProvider serviceProvider)
        {
            SubjectsViewModel subjectsViewModel = new SubjectsViewModel(
                    serviceProvider.GetRequiredService<IRepository<Subject>>(),
                    serviceProvider.GetRequiredService<BusyStore>()
            );

            subjectsViewModel.InitializeCollectionCommand.Execute(null);

            return subjectsViewModel;
        }

        protected override Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
