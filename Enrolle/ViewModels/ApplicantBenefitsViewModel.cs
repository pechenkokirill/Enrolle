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
    public class ApplicantBenefitsViewModel : TableEditBaseViewModel<ApplicantBenefit>
    {
        private readonly IRepository<Applicant> applicantsRepository;
        private readonly IRepository<Benefit> benefitsRepository;

        public ApplicantBenefitsViewModel(IRepository<Benefit> benefitsRepository, IRepository<Applicant> applicantsRepository, IRepository<ApplicantBenefit> repository, BusyStore busyStore) : base(repository, busyStore)
        {
            this.benefitsRepository = benefitsRepository;
            this.applicantsRepository = applicantsRepository;
        }

        public static ApplicantBenefitsViewModel BuildAndLoad(IServiceProvider serviceProvider)
        {
            ApplicantBenefitsViewModel applicantBenefitsViewModel = new ApplicantBenefitsViewModel(
                serviceProvider.GetRequiredService<IRepository<Benefit>>(),
                serviceProvider.GetRequiredService<IRepository<Applicant>>(),
                serviceProvider.GetRequiredService<IRepository<ApplicantBenefit>>(),
                serviceProvider.GetRequiredService<BusyStore>()
            );

            applicantBenefitsViewModel.InitializeCollectionCommand.Execute(null);

            return applicantBenefitsViewModel;
        }

        protected override async Task InitializeAsync()
        {
            await benefitsRepository.LoadAsync();
            Benefits = benefitsRepository.GetAll();
            await applicantsRepository.LoadAsync();
            Applicants = applicantsRepository.GetAll();
        }

        public IEnumerable<Applicant>? Applicants { get; set; } 
        public IEnumerable<Benefit>? Benefits { get; set; }

    }
}
