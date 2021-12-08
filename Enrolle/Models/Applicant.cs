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
        public int Id { get; set; }
        public string PassportId { get; set; } = "00000000000000";
        public string SecondName { get; set; } = "Фамилия";
        public string FirstName { get; set; } = "Имя";
        public string LastName { get; set; } = "Отчество";
        public string Address { get; set; } = "Адрес";
        public Specialization Specialization { get; set; }
        public bool InAbsentia { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
