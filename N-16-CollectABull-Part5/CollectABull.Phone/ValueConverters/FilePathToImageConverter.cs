using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.File;

namespace CollectABull.Phone.ValueConverters
{
    // inspired by http://www.j2i.net/blogEngine/post/2011/09/03/Displaying-an-Image-from-Isolated-Storage.aspx
    public class FilePathToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            if (!(value is string))
                return null;

            var fileStore = Mvx.Resolve<IMvxFileStore>();

            var bm = new BitmapImage();
            fileStore.TryReadBinaryFile((string)value, (stream) =>
                {
                    bm.SetSource(stream);
                    return true;
                });

            return bm;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
