using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Enrolle.Models
{
    public class Applicant
    {
        [Key]
        public string PassportId { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Specialization Specialization { get; set; }
        public bool InAbsentia { get; set; }
    }
}
