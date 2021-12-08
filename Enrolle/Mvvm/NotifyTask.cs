using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTesting.Mvvm
{
    public static class NotifyTask
    {
        public static NotifyTask<TResult> Call<TResult>(Func<Task<TResult>> task)
        {
            NotifyTask<TResult> notifyTask = new NotifyTask<TResult>(task);
            notifyTask.Run();
            return notifyTask;
        }
    }

    public sealed class NotifyTask<TResult> : ObservableObject
    {
        private TaskNotifier<TResult>? executionTask;
        private Func<Task<TResult>> task;

        public Task<TResult> ExecutionTask
        {
            get => this.executionTask!;
            private set => SetPropertyAndNotifyOnCompletion<TResult>(ref executionTask, value, (t) => OnPropertyChanged("Result"));
        }
        public TResult? Result => ExecutionTask.IsCompletedSuccessfully ? ExecutionTask.Result : default(TResult);
        public NotifyTask(Func<Task<TResult>> task)
        {
            this.task = task;
        }

        public void Run()
        {
            ExecutionTask = task();
        }
    }
}
