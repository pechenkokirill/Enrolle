using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable

namespace Enrolle.Validation
{
    public class ApplicantPassportIdValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Applicant applicant = (value as BindingGroup).Items[0] as Applicant;

            if (string.IsNullOrWhiteSpace(applicant.PassportId))
            {
                return new ValidationResult(false,
                    "Паспорт ID должен быть обязательно указан!");
            }
            else if(applicant.PassportId.Length < 14)
            {
                return new ValidationResult(false,
                   "Неверный размер паспорт ID! (необходимо 14 символов)");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
