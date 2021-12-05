using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Enrolle.Models
{
    public class ApplicantBenefit
    {
        public int Id { get; set; }
        public Applicant Applicant { get; set; }
        public Benefit Benefit { get; set; }
    }
}
