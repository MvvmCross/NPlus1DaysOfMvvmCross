using Books.Core.ValueConverters;
using Cirrious.CrossCore.WindowsStore.Converters;
using Cirrious.MvvmCross.Plugins.Visibility;

namespace Books.Store.ValueConverters
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
