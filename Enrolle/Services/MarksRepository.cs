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

        public async Task AddAsync(Mark item)
        {
            await dataContext.Marks.AddAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<Mark> items)
        {
            await dataContext.Marks.AddRangeAsync(items);
        }

        public IEnumerable<Mark> GetAll()
        {
            return dataContext.Marks.Local.ToObservableCollection();
        }

        public async Task LoadAsync()
        {
            await dataContext.Marks.Include(x => x.Applicant).ThenInclude(x => x.Marks).Include(x => x.Subject).LoadAsync();
        }

        public void Remove(Mark item)
        {
            dataContext.Marks.Remove(item);
            item.Applicant.Marks.Remove(item);
        }

        public async Task SaveAsync()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
