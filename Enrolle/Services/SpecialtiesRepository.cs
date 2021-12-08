using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Services
{
    public class SpecialtiesRepository : IRepository<Specialization>
    {
        private readonly DataContext dataContext;

        public SpecialtiesRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task AddAsync(Specialization item)
        {
            await dataContext.Specializations.AddAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<Specialization> items)
        {
            await dataContext.Specializations.AddRangeAsync(items);
        }

        public IEnumerable<Specialization> GetAll()
        {
            return dataContext.Specializations.Local.ToObservableCollection();
        }

        public async Task LoadAsync()
        {
            await dataContext.Specializations.LoadAsync();
        }

        public void Remove(Specialization item)
        {
            dataContext.Specializations.Remove(item);
        }

        public async Task SaveAsync()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
