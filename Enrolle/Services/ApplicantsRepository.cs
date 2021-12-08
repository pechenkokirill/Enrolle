using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Services
{
    public class ApplicantsRepository : IRepository<Applicant>
    {
        private readonly DataContext dataContext;

        public ApplicantsRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task AddAsync(Applicant item)
        {
            await dataContext.Applicants.AddAsync(item);
        }
        public async Task AddRangeAsync(IEnumerable<Applicant> items)
        {
            await dataContext.Applicants.AddRangeAsync(items);
        }

        public IEnumerable<Applicant> GetAll()
        {
            return dataContext.Applicants.Local.ToObservableCollection();
        }

        public async Task LoadAsync()
        {
            await dataContext.Applicants.Include(x => x.Specialization).LoadAsync();
        }

        public void Remove(Applicant item)
        {
            dataContext.Applicants.Remove(item);
        }

        public async Task SaveAsync()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
