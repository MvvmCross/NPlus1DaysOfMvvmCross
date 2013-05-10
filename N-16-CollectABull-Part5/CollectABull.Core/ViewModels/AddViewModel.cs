using System;
using System.IO;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.Plugins.PictureChooser;
using Cirrious.MvvmCross.ViewModels;
using CollectABull.Core.Services.Collections;
using CollectABull.Core.Services.DataStore;
using CollectABull.Core.Services.Location;

namespace CollectABull.Core.ViewModels
{
    public class AddViewModel
        : MvxViewModel
    {
        private readonly ICollectionService _collectionService;
        private readonly ILocationService _locationService;
        private readonly IMvxPictureChooserTask _pictureChooserTask;
        private readonly IMvxFileStore _fileStore;
        private readonly MvxSubscriptionToken _token;

        public AddViewModel(
            ICollectionService collectionService, 
            ILocationService locationService, 
            IMvxMessenger messenger, 
            IMvxPictureChooserTask pictureChooserTask, IMvxFileStore fileStore)
        {
            _collectionService = collectionService;
            _locationService = locationService;
            _pictureChooserTask = pictureChooserTask;
            _fileStore = fileStore;
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

        private Cirrious.MvvmCross.ViewModels.MvxCommand _addPictureCommand;
        public System.Windows.Input.ICommand AddPictureCommand
        {
            get
            {
                _addPictureCommand = _addPictureCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoAddPicture);
                return _addPictureCommand;
            }
        }

        private void DoAddPicture()
        {
            // do action
            // TODO - put this back to TakePicture
            _pictureChooserTask.ChoosePictureFromLibrary(400, 95, OnPicture, () => { /* nothing to */ });
            //_pictureChooserTask.TakePicture(400, 95, OnPicture, () => { /* nothing to */ });
        }

        private void OnPicture(Stream stream)
        {
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            PictureBytes = memoryStream.ToArray();
        }

        private byte[] _pictureBytes;
        public byte[] PictureBytes
        {
            get { return _pictureBytes; }
            set { _pictureBytes = value; RaisePropertyChanged(() => PictureBytes); }
        }
        
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
                    ImagePath = GenerateImagePath(),
                    Lat = Latitude,
                    Lng = Longitude,
                    LocationKnown = LocationKnown,
                    Notes = Notes,
                    WhenUtc = DateTime.UtcNow
                };

            _collectionService.Add(collectedItem);
            Close(this);
        }

        private string GenerateImagePath()
        {
            if (PictureBytes == null)
                return null;

            var randomFileName = "Image" + Guid.NewGuid().ToString("N") + ".jpg";
            _fileStore.EnsureFolderExists("Images");
            var path = _fileStore.PathCombine("Images", randomFileName);
            _fileStore.WriteFile(path, PictureBytes);
            return path;
        }

        // TODO - would be nice if the editor auto-validated - e.g. enable/disabling the save button
        private bool Validate()
        {
            if (string.IsNullOrEmpty(Caption))
                return false;

            //if (PictureBytes == null)
            //    return false;

            return true;
        }
    }
}
