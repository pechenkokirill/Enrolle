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

        public void Add(Benefit item)
        {
            dataContext.Benefits.Add(item);
        }

        public Benefit? Get(int id)
        {
            return dataContext.Benefits.Find(id);
        }

        public IEnumerable<Benefit> GetAll()
        {
            return dataContext.Benefits.Local.ToObservableCollection();
        }

        public void Load()
        {
            dataContext.Benefits.Load();
        }

        public void Remove(Benefit item)
        {
            dataContext.Benefits.Remove(item);
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }
    }
}
