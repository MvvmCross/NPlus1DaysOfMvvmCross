using Cirrious.MvvmCross.ViewModels;

namespace Mappit.Core.ViewModels
{
    public class Location
        : MvxNotifyPropertyChanged
    {
        private double _lat;
        public double Lat 
        {   
            get { return _lat; }
            set { _lat = value; RaisePropertyChanged(() => Lat); }
        }

        private double _lng;
        public double Lng 
        {   
            get { return _lng; }
            set { _lng = value; RaisePropertyChanged(() => Lng); }
        }
    }

    public class Zombie
        : MvxNotifyPropertyChanged
    {
        private string _name;
        public string Name 
        {   
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }

        private Location _location;
        public Location Location 
        {   
            get { return _location; }
            set { _location = value; RaisePropertyChanged(() => Location); }
        }

        private bool _isMale;
        public bool IsMale 
        {   
            get { return _isMale; }
            set { _isMale = value; RaisePropertyChanged(() => IsMale); }
        }
    }

    public class FirstViewModel 
		: MvxViewModel
    {
        private Zombie _helen;
        public Zombie Helen 
        {   
            get { return _helen; }
            set { _helen = value; RaisePropertyChanged(() => Helen); }
        }

        private Zombie _keith;
        public Zombie Keith 
        {   
            get { return _keith; }
            set { _keith = value; RaisePropertyChanged(() => Keith); }
        }

        public FirstViewModel()
        {
            Helen = new Zombie()
                {
                    Name = "Helen",
                    Location = new Location()
                        {
                            Lat = 51.4,
                            Lng = 0.4
                        },
                };
            Keith = new Zombie()
            {
                IsMale = true,
                Name = "Keith",
                Location = new Location()
                {
                    Lat = 51.5,
                    Lng = 0.3
                }
            };
        }

        public IMvxCommand MoveCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        Keith.Location = new Location()
                            {
                                Lat = Keith.Location.Lat + 0.1,
                                Lng = Keith.Location.Lng
                            };

                        Helen.Location = new Location()
                        {
                            Lat = Helen.Location.Lat - 0.1,
                            Lng = Helen.Location.Lng
                        };

                    });
            }
        }
    }
}
