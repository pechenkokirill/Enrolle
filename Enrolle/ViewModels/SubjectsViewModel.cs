using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.ViewModels
{
    public class SubjectsViewModel : TableEditBaseViewModel<Subject>
    {
        public SubjectsViewModel(IRepository<Subject> repository) : base(repository)
        {
        }
    }
}
