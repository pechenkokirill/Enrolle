using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.ViewModels
{
    public class ApplicantsViewModel : TableEditBaseViewModel<Applicant>
    {
        private readonly IRepository<Specialization> specializationRepo;
        public IEnumerable<Specialization>? Specializations { get; set; }
        public ApplicantsViewModel(IRepository<Specialization> specializationRepo, IRepository<Applicant> repository, BusyStore busyStore) : base(repository, busyStore)
        {
            this.specializationRepo = specializationRepo;
        }

        public static ApplicantsViewModel BuildAndLoad(IServiceProvider serviceProvider)
        {
            ApplicantsViewModel applicantsViewModel = new ApplicantsViewModel(
                serviceProvider.GetRequiredService<IRepository<Specialization>>(),    
                serviceProvider.GetRequiredService<IRepository<Applicant>>(),    
                serviceProvider.GetRequiredService<BusyStore>()
            );

            applicantsViewModel.InitializeCollectionCommand.Execute(null);
            return applicantsViewModel;
        }

        protected override async Task InitializeAsync()
        {
            await specializationRepo.LoadAsync();   
            Specializations = specializationRepo.GetAll();
        }

    }
}
