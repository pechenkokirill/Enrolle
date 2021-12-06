using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Enrolle.Converters
{
    public class StringToFormOfEducationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool v = (bool)value;

            if (v)
            {
                return "Заочная";
            }
            else
            {
                return "Очная";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ComboBoxItem? comboBoxItem = value as ComboBoxItem;
            if (comboBoxItem is null)
                return false;
            string text = comboBoxItem.Content as string ?? "";

            switch (text)
            {
                case "Очная":
                    return false;
                case "Заочная":
                    return true;
                default:
                    return false;
            }
        }
    }
}
