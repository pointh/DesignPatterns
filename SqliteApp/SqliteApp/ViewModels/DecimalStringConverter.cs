using System;
using Xamarin.Forms;
using System.Globalization;

namespace SqliteApp.ViewModels
{
    public class DecimalStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((decimal)value).ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((string)value)[((string)value).Length - 1] == '.')
                return value;

            if (decimal.TryParse((string)value, out decimal d))
            {
                return d;
            }
            else
                return value;
        }
    }
}
