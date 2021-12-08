using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Enrolle.Converters
{
    public class MarkConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int intValue = System.Convert.ToInt32(value);
                return Math.Clamp(intValue, 1, 10);
            }
            catch
            {
                return 1;
            }
        }
    }
}
