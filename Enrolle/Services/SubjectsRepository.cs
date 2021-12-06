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

        public void Add(Subject item)
        {
            dataContext.Subjects.Add(item);
        }

        public Subject? Get(int id)
        {
            return dataContext.Subjects.Find(id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return dataContext.Subjects.Local.ToObservableCollection();
        }

        public void Load()
        {
            dataContext.Subjects.Load();
        }

        public void Remove(Subject item)
        {
            dataContext.Subjects.Remove(item);
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }
    }
}
