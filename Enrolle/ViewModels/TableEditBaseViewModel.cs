using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
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
    public abstract class TableEditBaseViewModel<T> : ObservableObject where T : class
    {
        private readonly IRepository<T> repository;
        private readonly BusyStore busyStore;

        public AsyncRelayCommand SaveCommand { get; set; }
        public AsyncRelayCommand InitializeCollectionCommand { get; set; }
        public ICollection<T>? Collection { get; set; }
        public TableEditBaseViewModel(IRepository<T> repository, BusyStore busyStore)
        {
            this.repository = repository;
            this.busyStore = busyStore;
            SaveCommand = new AsyncRelayCommand(SaveAsync);
            InitializeCollectionCommand = new AsyncRelayCommand(LoadDataAsync);
        }

        private async Task LoadDataAsync()
        {
            busyStore.IsBusy = true;
            try
            {
                await InitializeAsync();
                await InitializeCollectionAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Упс...");
            }
            finally
            {
                busyStore.IsBusy = false;
            }
        }
        protected abstract Task InitializeAsync();

        private async Task InitializeCollectionAsync()
        {
            //Simulates heavy work
            await Task.Delay(1000);
            await repository.LoadAsync();
            ObservableCollection<T> obsevalbe = new ObservableCollection<T>(repository.GetAll());
            obsevalbe.CollectionChanged += Obsevalbe_CollectionChanged;
            Collection = obsevalbe;
        }

        private async void Obsevalbe_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove ||
                e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (var item in e.OldItems!)
                {
                    repository.Remove((T)item);
                }
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add ||
                e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                foreach (var item in e.NewItems!)
                {
                    await repository.AddAsync((T)item);
                }
            }

            
        }

        private async Task SaveAsync()
        {
            var result = MessageBox.Show("Вы точно хотите сохранить файл?", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                busyStore.IsBusy = true;
                try
                {
                    await repository.SaveAsync();
                    MessageBox.Show("Файл сохранен!");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Упс...");
                }
                finally
                {
                    busyStore.IsBusy = false;
                }
            }

        }
    }
}
