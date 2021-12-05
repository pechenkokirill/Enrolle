using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace Enrolle.Models
{
    public enum MarkType
    {
        Certificate,
        CentralizedTesting
    }
    public class Mark
    {
        public int Id { get; set; }
        public Applicant Applicant { get; set; }
        public Subject Subject { get; set; }
        public int Value { get; set; }
        public MarkType Type { get; set; }
    }
}
