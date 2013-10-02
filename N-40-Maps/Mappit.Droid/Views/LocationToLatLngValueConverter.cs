using Android.Gms.Maps.Model;
using Cirrious.CrossCore.Converters;
using Mappit.Core.ViewModels;

namespace Mappit.Droid.Views
{
    public class LocationToLatLngValueConverter : MvxValueConverter<Location, LatLng>
    {
        protected override LatLng Convert(Location value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new LatLng(value.Lat, value.Lng);
        }

        protected override Location ConvertBack(LatLng value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Location() { Lat = value.Latitude, Lng = value.Longitude };
        }
    }
}