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
        private readonly MarksViewModel marksViewModel;
        private readonly BusyStore busyStore;
        private readonly INavigation navigation;

        public Applicant? Applicant { get; set; }
        public IEnumerable<Applicant> Applicants => marksViewModel.Applicants!.Where(x => x.Marks is null || x.Marks.Count == 0);
        public IEnumerable<Subject> Subjects => marksViewModel.Subjects!;
        public IEnumerable<Mark>? Marks { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public MarksAddViewModel(MarksViewModel marksViewModel, BusyStore busyStore, INavigation navigation)
        {
            this.marksViewModel = marksViewModel;
            this.busyStore = busyStore;
            this.navigation = navigation;
            Marks = CreateMarks();
            AddCommand = new RelayCommand(Add, () => Applicant is not null);
            BackCommand = new RelayCommand(Back);
        }

        private ObservableCollection<Mark> CreateMarks()
        {
            return new ObservableCollection<Mark>(Subjects.Select(x => new Mark() { Subject = x, Value = 1 }));
        }

        private void Back()
        {
            navigation.Navigate(typeof(MarksViewModel));
        }

        private void Add()
        {
            var result = MessageBox.Show("Вы точно хотите добавить записи?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (busyStore.SetBusy())
                {
                    if (Marks is not null)
                    {
                        foreach (Mark mark in Marks)
                        {
                            mark.Applicant = Applicant;
                            marksViewModel.Collection!.Add(mark);
                        }
                    }
                }

                BackCommand.Execute(null);
            }
        }
    }
}
