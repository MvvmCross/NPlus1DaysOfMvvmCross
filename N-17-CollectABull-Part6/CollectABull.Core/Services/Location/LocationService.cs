using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace CollectABull.Core.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly IMvxGeoLocationWatcher _watcher;
        private readonly IMvxMessenger _messenger;

        public LocationService(IMvxGeoLocationWatcher watcher, IMvxMessenger messenger)
        {
            _messenger = messenger;

            _watcher = watcher;
            _watcher.Start(new MvxGeoLocationOptions(), OnSuccess, OnError);
        }

        private readonly object _lockObject  = new object();
        private MvxGeoLocation _latestLocation;

        private void OnSuccess(MvxGeoLocation location)
        {
            lock (_lockObject)
            {
                _latestLocation = location;
            }

            var message = new LocationMessage(this, 
                                location.Coordinates.Latitude, 
                                location.Coordinates.Longitude);

            _messenger.Publish(message);
        }

        private void OnError(MvxLocationError error)
        {
            Mvx.Warning("Error seen during location {0}", error.Code);
        }

        public bool TryGetLatestLocation(out double lat, out double lng)
        {
            lock (_lockObject)
            {
                if (_latestLocation == null)
                {
                    lat = lng = 0;
                    return false;
                }

                lat = _latestLocation.Coordinates.Latitude;
                lng = _latestLocation.Coordinates.Longitude;
                return true;
            }
        }
    }
}
