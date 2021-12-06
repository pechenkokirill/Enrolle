using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolle.ViewModels
{
    public class BenefitsViewModel : TableEditBaseViewModel<Benefit>
    {
        public BenefitsViewModel(IRepository<Benefit> repository) : base(repository)
        {
        }
    }
}
