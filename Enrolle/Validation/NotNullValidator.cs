using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable

namespace Enrolle.Validation
{
    public class NotNullValidator : ValidationRule
    {
        public string PropertyName { get; set; }
        public string HeaderName { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            object bindingValue = (value as BindingGroup).Items[0];
            Type type = bindingValue.GetType();

            object? result = type.GetProperty(PropertyName)!.GetValue(bindingValue);

            if(result is null)
            {
                return new ValidationResult(false,
                    $"Поле '{HeaderName}' должно быть заполнено!");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
