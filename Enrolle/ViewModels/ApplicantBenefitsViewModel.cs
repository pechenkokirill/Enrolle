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

        public IEnumerable<Applicant> Applicants => new ObservableCollection<Applicant>(applicantsRepository.GetAll());
        public IEnumerable<Benefit> Benefits => new ObservableCollection<Benefit>(benefitsRepository.GetAll());
        public ApplicantBenefitsViewModel(IRepository<ApplicantBenefit> repository, IRepository<Applicant> applicantsRepository, IRepository<Benefit> benefitsRepository) : base(repository)
        {
            this.applicantsRepository = applicantsRepository;
            this.applicantsRepository.Load();
            this.benefitsRepository = benefitsRepository;
            this.benefitsRepository.Load();
        }
    }
}
