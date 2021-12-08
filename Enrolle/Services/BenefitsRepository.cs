using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Services
{
    public class BenefitsRepository : IRepository<Benefit>
    {
        private readonly DataContext dataContext;

        public BenefitsRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        ~BenefitsRepository()
        {
            dataContext.Dispose();
        }
        public async Task AddAsync(Benefit item)
        {
            await dataContext.Benefits.AddAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<Benefit> items)
        {
            await dataContext.Benefits.AddRangeAsync(items);
        }

        public async Task SaveAsync()
        {
            await dataContext.SaveChangesAsync();
        }

        public void Remove(Benefit item)
        {
            dataContext.Benefits.Remove(item);
        }

        public IEnumerable<Benefit> GetAll()
        {
            return dataContext.Benefits.Local.ToObservableCollection();
        }

        public async Task LoadAsync()
        {
            await dataContext.Benefits.LoadAsync();
        }
    }
}
