using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Services
{
    public class ApplicantBenefitsRepository : IRepository<ApplicantBenefit>
    {
        private readonly DataContext dataContext;

        public ApplicantBenefitsRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task AddAsync(ApplicantBenefit item)
        {
            await dataContext.ApplicantBenefits.AddAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<ApplicantBenefit> items)
        {
            await dataContext.ApplicantBenefits.AddRangeAsync(items);
        }

        public IEnumerable<ApplicantBenefit> GetAll()
        {
            return dataContext.ApplicantBenefits.Local.ToObservableCollection();
        }

        public async Task LoadAsync()
        {
            await dataContext.ApplicantBenefits.Include(x => x.Applicant).Include(x => x.Benefit).LoadAsync();
        }

        public void Remove(ApplicantBenefit item)
        {
            dataContext.ApplicantBenefits.Remove(item);
        }

        public async Task SaveAsync()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
