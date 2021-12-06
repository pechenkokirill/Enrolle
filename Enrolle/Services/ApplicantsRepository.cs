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

        public void Add(Applicant item)
        {
            dataContext.Applicants.Add(item);
        }

        public Applicant? Get(int id)
        {
            return dataContext.Applicants.Find(id);
        }

        public IEnumerable<Applicant> GetAll()
        {
            return dataContext.Applicants.Local.ToObservableCollection();
        }

        public void Load()
        {
            dataContext.Applicants.Include(x => x.Specialization).Load();
        }

        public void Remove(Applicant item)
        {
            dataContext.Applicants.Remove(item);
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }
    }
}
