using Enrolle.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Services
{
    public class MarksRepository : IRepository<Mark>
    {
        private readonly DataContext dataContext;

        public MarksRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(Mark item)
        {
            dataContext.Marks.Add(item);
        }

        public Mark? Get(int id)
        {
            return dataContext.Marks.Find(id);
        }

        public IEnumerable<Mark> GetAll()
        {
            return dataContext.Marks.Local.ToObservableCollection();
        }

        public void Load()
        {
            dataContext.Marks.Include(x => x.Applicant).Include(x => x.Subject).Load();
        }

        public void Remove(Mark item)
        {
            dataContext.Marks.Remove(item);
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }
    }
}
