using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Services
{
    public class SubjectsRepository : IRepository<Subject>
    {
        private readonly DataContext dataContext;

        public SubjectsRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task AddAsync(Subject item)
        {
            await dataContext.Subjects.AddAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<Subject> items)
        {
            await dataContext.Subjects.AddRangeAsync(items);
        }

        public IEnumerable<Subject> GetAll()
        {
            return dataContext.Subjects.Local.ToObservableCollection();
        }

        public async Task LoadAsync()
        {
            await dataContext.Subjects.LoadAsync();
        }

        public void Remove(Subject item)
        {
            dataContext.Subjects.Remove(item);
        }

        public async Task SaveAsync()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
