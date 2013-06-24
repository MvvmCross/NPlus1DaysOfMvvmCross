using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Location;

namespace ChimpLight
{
    public class PersonViewModel
        : INotifyPropertyChanged
    {
        private Activity1 _parent; 

        public PersonViewModel(Activity1 parent)
        {
            _parent = parent;

            var location = Mvx.Resolve<IMvxGeoLocationWatcher>();
            location.Start(new MvxGeoLocationOptions(), OnSuccess, OnError);
        }

        private void OnError(MvxLocationError obj)
        {
            // ignored!
        }

        private void OnSuccess(MvxGeoLocation obj)
        {
            _parent.RunOnUiThread(() => {
                                            Lat = obj.Coordinates.Latitude;
                                            Lng = obj.Coordinates.Longitude;
                            });
        }

        private string _firstName= "Fred";
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); OnPropertyChanged("FullName"); }
        }

        private string _lastName= "Flintstone";

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); OnPropertyChanged("FullName"); }
        }
        
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); }}

        private double _lat;
        public double Lat
        {
            get { return _lat; }
            set { _lat = value; OnPropertyChanged("Lat"); }
        }

        private double _lng;
        public double Lng
        {
            get { return _lng; }
            set { _lng = value; OnPropertyChanged("Lng"); }
        }
        public ICommand ResetCommand
        {
            get
            {
                return new MyRelayCommand(() =>
                    {
                        FirstName = "F";
                        LastName = "L";
                    });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}