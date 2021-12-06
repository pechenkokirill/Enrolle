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
        public IEnumerable<Specialization> Specializations => new ObservableCollection<Specialization>(specializationRepo.GetAll());
        public ApplicantsViewModel(IRepository<Applicant> repository, IRepository<Specialization> specializationRepo) : base(repository)
        {
            this.specializationRepo = specializationRepo;
            this.specializationRepo.Load();
        }
    }
}
