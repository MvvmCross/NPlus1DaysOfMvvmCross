using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore.Converters;

namespace Value.Core.Converters
{
    public enum Special
    {
        WindowsPhone,
        Android,
        iOS
    }

    public class SpecialValueConverter
        : MvxValueConverter<string, Special>
    {
        protected override Special Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            value = value ?? "";
            if (value.Length < 3)
                return Special.iOS;
            if (value.Length < 6)
                return Special.WindowsPhone;
            return Special.Android;
        }
    }
}
