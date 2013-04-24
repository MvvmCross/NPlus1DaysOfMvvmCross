using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore.Converters;

namespace Value.Core.Converters
{
    public class StringReverseValueConverter
        : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Reverse(value);
        }

        protected override string ConvertBack(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Reverse(value);
        }

        private static string Reverse(string value)
        {
            value = value ?? "";
            var stringBuilder = new StringBuilder(value.Length);
            for (var i = value.Length - 1; i >= 0; i--)
                stringBuilder.Append(value[i]);

            return stringBuilder.ToString();
        }
    }
}
