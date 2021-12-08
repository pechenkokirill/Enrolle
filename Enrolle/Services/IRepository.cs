using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Services
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        Task LoadAsync();
        Task AddAsync(T item);
        void Remove(T item);
        Task AddRangeAsync(IEnumerable<T> items);
        Task SaveAsync();
    }
}
