using System;
using System.Globalization;
using Cimbalino.Toolkit.Converters;

namespace MultiBinding
{
    public class FullNameConverter : MultiValueConverterBase
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                return null;
            }

            return string.Join(" ", values);
        }

        public override object[] ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = (string)value + " ";

            var values = stringValue.Split(' ');

            return new object[] { values[0], values[1] };
        }
    }
}