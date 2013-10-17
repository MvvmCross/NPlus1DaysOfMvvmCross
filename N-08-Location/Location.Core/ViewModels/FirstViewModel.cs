using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.MvvmCross.ViewModels;

namespace Location.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private readonly IMvxLocationWatcher _watcher;

        public FirstViewModel(IMvxLocationWatcher watcher)
        {
            _watcher = watcher;
            _watcher.Start(new MvxLocationOptions(), OnLocation, OnError);
        }

        private void OnLocation(MvxGeoLocation location)
        {
            Lat = location.Coordinates.Latitude;
            Lng = location.Coordinates.Longitude;
        }

        private void OnError(MvxLocationError error)
        {
            Mvx.Error("Seen location error {0}", error.Code);
        }

        private double _lng;
        public double Lng
        {
            get { return _lng; }
            set { _lng = value; RaisePropertyChanged(() => Lng); }
        }

        private double _lat;
        public double Lat
        {
            get { return _lat; }
            set { _lat = value; RaisePropertyChanged(() => Lat); }
        }
    }
}
