using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Enrolle.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PassingScore { get; set; }
        public int PaidPassingScore { get; set; }
        public int MaxApplicants { get; set; }
        public int PaidMaxApplicants { get; set; }
    }
}
