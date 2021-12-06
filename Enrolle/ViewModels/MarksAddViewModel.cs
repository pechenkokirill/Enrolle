using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Enrolle.ViewModels
{
    public class MarksAddViewModel : ObservableObject
    {
        private readonly IRepository<Applicant> applicantsRepo;
        private readonly IRepository<Subject> subjectRepo;
        private readonly IRepository<Mark> marksRepo;
        private readonly INavigation navigation;
        private Applicant applicant;

        public Applicant Applicant { get => applicant; set { applicant = value; Marks = CreateMarks(); } }
        public IEnumerable<Applicant> Applicants => new ObservableCollection<Applicant>(applicantsRepo.GetAll());
        public IEnumerable<Mark> Marks { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public MarksAddViewModel(IRepository<Applicant> applicantsRepo, IRepository<Subject> subjectRepo, IRepository<Mark> marksRepo, INavigation navigation)
        {
            this.applicantsRepo = applicantsRepo;
            this.subjectRepo = subjectRepo;
            this.marksRepo = marksRepo;
            this.navigation = navigation;
            this.subjectRepo.Load();
            this.applicantsRepo.Load();
            AddCommand = new RelayCommand(Add, () => Applicant is not null);
            BackCommand = new RelayCommand(Back);
        }

        private void Back()
        {
            navigation.Navigate(typeof(MarksViewModel));
        }

        private IEnumerable<Mark> CreateMarks()
        {
            IEnumerable<Subject> subjects = subjectRepo.GetAll();
            return new ObservableCollection<Mark>(subjects.Select(x => new Mark() { Applicant = Applicant, Subject = x }));
        }

        private void Add()
        {
            var result = MessageBox.Show("Вы точно хотите добавить записи?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                foreach (var mark in Marks)
                {
                    marksRepo.Add(mark);
                }

                navigation.Navigate(typeof(MarksViewModel));
            }
        }
    }
}
