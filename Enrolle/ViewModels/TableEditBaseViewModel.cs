using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Enrolle.ViewModels
{
    public class TableEditBaseViewModel<T> : ObservableObject where T : class
    {
        private readonly IRepository<T> repository;
        public RelayCommand SaveCommand { get; set; }
        public ICollectionView Collection { get; set; }
        public TableEditBaseViewModel(IRepository<T> repository)
        {
            this.repository = repository;
            repository.Load();
            Collection = CollectionViewSource.GetDefaultView(repository.GetAll());
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            var result = MessageBox.Show("Вы точно хотите сохранить файл?", "", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    repository.Save();
                    MessageBox.Show("Файл сохранен!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Упс...");
                }
            }
            
        }
    }
}
