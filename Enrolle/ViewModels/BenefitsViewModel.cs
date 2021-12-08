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
    public class BenefitsViewModel : TableEditBaseViewModel<Benefit>
    {
        public BenefitsViewModel(IRepository<Benefit> repository, BusyStore busyStore) : base(repository, busyStore)
        {
        }

        public static BenefitsViewModel BuildAndLoad(IServiceProvider serviceProvider)
        {
            BenefitsViewModel benefitsViewModel = new BenefitsViewModel(
                serviceProvider.GetRequiredService<IRepository<Benefit>>(),
                serviceProvider.GetRequiredService<BusyStore>()
            );
            benefitsViewModel.InitializeCollectionCommand.Execute(null);
            return benefitsViewModel;
        }

        protected override Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
