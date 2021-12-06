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

        public void Add(ApplicantBenefit item)
        {
            dataContext.ApplicantBenefits.Add(item);
        }

        public ApplicantBenefit? Get(int id)
        {
            return dataContext.ApplicantBenefits.Find(id);
        }

        public IEnumerable<ApplicantBenefit> GetAll()
        {
            return dataContext.ApplicantBenefits.Local.ToObservableCollection();
        }

        public void Load()
        {
            dataContext.ApplicantBenefits.Load();
        }

        public void Remove(ApplicantBenefit item)
        {
            dataContext.ApplicantBenefits.Remove(item);
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }
    }
}
