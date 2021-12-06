using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.Services
{
    public interface IRepository
    {
        void Load();
        void Save();
    }

    public interface IRepository<T> : IRepository where T: class
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        void Add(T item);
        void Remove(T item);
    }
}
