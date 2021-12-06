using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Enrolle.Converters
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is null || parameter is null)
                return value;
            Type enumType = parameter as Type;
            FieldInfo field = enumType.GetField(value.ToString());
            if (field is null)
                return value;
            DescriptionAttribute descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
            if(descriptionAttribute is not null)
            {
                return descriptionAttribute.Description;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
