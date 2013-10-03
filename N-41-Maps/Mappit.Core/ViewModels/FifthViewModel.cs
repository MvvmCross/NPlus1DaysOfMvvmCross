using Cirrious.MvvmCross.ViewModels;

namespace Mappit.Core.ViewModels
{
    public class FifthViewModel 
		: MvxViewModel
    {
        private Location _location;
        public Location Location 
        {   
            get { return _location; }
            set { _location = value; RaisePropertyChanged(() => Location); }
        }

        public FifthViewModel()
        {
            Location = new Location()
                {
                    Lat = 51.4,
                    Lng = 0.4
                };
        }
    }
}
