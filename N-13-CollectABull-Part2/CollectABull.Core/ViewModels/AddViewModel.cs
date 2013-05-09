using System;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using CollectABull.Core.Services.Collections;
using CollectABull.Core.Services.DataStore;
using CollectABull.Core.Services.Location;

namespace CollectABull.Core.ViewModels
{
    public class AddViewModel
        : MvxViewModel
    {
        private ICollectionService _collectionService;
        private ILocationService _locationService;
        private MvxSubscriptionToken _token;

        public AddViewModel(ICollectionService collectionService, ILocationService locationService, IMvxMessenger messenger)
        {
            _collectionService = collectionService;
            _locationService = locationService;
            _token = messenger.SubscribeOnMainThread<LocationMessage>(OnLocation);
            GetInitialLocation();
        }

        private void GetInitialLocation()
        {
            double lat, lng;
            if (_locationService.TryGetLatestLocation(out lat, out lng))
            {
                LocationKnown = true;
                Latitude = lat;
                Longitude = lng;
            }
        }

        private void OnLocation(LocationMessage location)
        {
            LocationKnown = true;
            Latitude = location.Lat;
            Longitude = location.Lng;
        }

        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; RaisePropertyChanged(() => Caption); }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; RaisePropertyChanged(() => Notes); }
        }

        private bool _locationKnown;
        public bool LocationKnown
        {
            get { return _locationKnown; }
            set { _locationKnown = value; RaisePropertyChanged(() => LocationKnown); }
        }

        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; RaisePropertyChanged(() => Latitude); }
        }

        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; RaisePropertyChanged(() => Longitude); }
        }

        
        /*

         * TODO !
        public string ImagePath { get; set; }

         */

        private Cirrious.MvvmCross.ViewModels.MvxCommand _saveCommand;
        public System.Windows.Input.ICommand SaveCommand
        {
            get
            {
                _saveCommand = _saveCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoSave);
                return _saveCommand;
            }
        }

        private void DoSave()
        {
            // do action
            if (!Validate())
                return;

            var collectedItem = new CollectedItem()
                {
                    Caption = Caption,
                    ImagePath = null, // TODO
                    Lat = Latitude,
                    Lng = Longitude,
                    LocationKnown = LocationKnown,
                    Notes = Notes,
                    WhenUtc = DateTime.UtcNow
                };

            _collectionService.Add(collectedItem);
            Close(this);
        }

        // TODO - would be nice if the editor auto-validated - e.g. enable/disabling the save button
        private bool Validate()
        {
            if (string.IsNullOrEmpty(Caption))
                return false;

            return true;
        }
    }
}
