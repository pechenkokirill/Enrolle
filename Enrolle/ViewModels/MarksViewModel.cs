using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Enrolle.ViewModels
{
    public class MarksViewModel : TableEditBaseViewModel<Mark>
    {
        private readonly IRepository<Applicant> applicantsRepository;
        private readonly IRepository<Subject> subjectsRepository;
        private readonly INavigation navigation;
        public IEnumerable<Applicant>? Applicants { get; set; }
        public IEnumerable<Subject>? Subjects { get; set; }
        public RelayCommand GoToAddCommand { get; set; }
        public RelayCommand<IEnumerable<object>> RemoveMarksCommand { get; set; }

        public MarksViewModel(IRepository<Mark> repository,IRepository<Applicant> applicantsRepository, IRepository<Subject> subjectsRepository, INavigation navigation, BusyStore busyStore) : base(repository, busyStore)
        {
            this.navigation = navigation;
            this.applicantsRepository = applicantsRepository;
            this.subjectsRepository = subjectsRepository;

            GoToAddCommand = new RelayCommand(GoToAdd);
            RemoveMarksCommand = new RelayCommand<IEnumerable<object>>(RemoveMarks!);
        }

        public static MarksViewModel BuildAndLoad(IServiceProvider serviceProvider)
        {
            MarksViewModel marksViewModel = new MarksViewModel(
                    serviceProvider.GetRequiredService<IRepository<Mark>>(),
                    serviceProvider.GetRequiredService<IRepository<Applicant>>(),
                    serviceProvider.GetRequiredService<IRepository<Subject>>(),
                    serviceProvider.GetRequiredService<INavigation>(),
                    serviceProvider.GetRequiredService<BusyStore>()
                );

            marksViewModel.InitializeCollectionCommand.Execute(null);

            return marksViewModel;
        }

        private void RemoveMarks(IEnumerable<object> marks)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить отметки?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                foreach (Mark mark in marks.ToList())
                {
                    Collection!.Remove(mark);
                }
            }
        }

        private void GoToAdd()
        {
            navigation.Navigate(typeof(MarksAddViewModel));
        }

        protected override async Task InitializeAsync()
        {
            await applicantsRepository.LoadAsync();
            Applicants = applicantsRepository.GetAll();
            await subjectsRepository.LoadAsync();
            Subjects = subjectsRepository.GetAll();
        }
    }
}
