using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.ViewModels
{
    public class MarksViewModel : TableEditBaseViewModel<Mark>
    {
        private readonly IRepository<Applicant> applicantsRepository;
        private readonly IRepository<Subject> subjectsRepository;
        private readonly INavigation navigation;

        public IEnumerable<Applicant> Applicants => new ObservableCollection<Applicant>(applicantsRepository.GetAll());
        public IEnumerable<Subject> Subjects => new ObservableCollection<Subject>(subjectsRepository.GetAll());
        public RelayCommand GoToAddCommand { get; set; }

        public MarksViewModel(IRepository<Mark> repository, IRepository<Applicant> applicantsRepository, IRepository<Subject> subjectsRepository, INavigation navigation) : base(repository)
        {
            this.navigation = navigation;
            this.applicantsRepository = applicantsRepository;
            this.applicantsRepository.Load();
            this.subjectsRepository = subjectsRepository;
            this.subjectsRepository.Load();

            GoToAddCommand = new RelayCommand(GoToAdd);
        }

        private void GoToAdd()
        {
            navigation.Navigate(typeof(MarksAddViewModel));
        }
    }
}
