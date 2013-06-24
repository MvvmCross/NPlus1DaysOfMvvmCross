using System;
using Cirrious.CrossCore.Converters;

namespace ChimpLight
{
    public class LengthValueConverter : MvxValueConverter<string, int>
    {
        protected override int Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return 0;
            return value.Length;
        }
    }
}