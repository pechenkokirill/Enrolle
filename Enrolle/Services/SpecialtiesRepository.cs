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

        public void Add(Specialization item)
        {
            dataContext.Specializations.Add(item);
        }

        public Specialization? Get(int id)
        {
            return dataContext.Specializations.Find(id);
        }

        public IEnumerable<Specialization> GetAll()
        {
            return dataContext.Specializations.Local.ToObservableCollection();
        }

        public void Load()
        {
            dataContext.Specializations.Load();
        }

        public void Remove(Specialization item)
        {
            dataContext.Specializations.Remove(item);
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }
    }
}
