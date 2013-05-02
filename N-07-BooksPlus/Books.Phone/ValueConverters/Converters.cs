using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Books.Core.ValueConverters;
using Cirrious.CrossCore.WindowsPhone.Converters;
using Cirrious.MvvmCross.Plugins.Visibility;

namespace Books.Phone.ValueConverters
{
    public class NativeVisibilityConverter : MvxNativeValueConverter<MvxVisibilityValueConverter>
    {
    }

    public class NativeInvertedVisibilityConverter : MvxNativeValueConverter<MvxInvertedVisibilityValueConverter>
    {
    }

    public class NativeInverseBoolConverter : MvxNativeValueConverter<InverseBoolValueConverter>
    {
    }
}
