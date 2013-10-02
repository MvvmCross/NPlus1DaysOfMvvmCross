using Cirrious.MvvmCross.ViewModels;

namespace Mappit.Core.ViewModels
{
    public class SecondViewModel 
		: MvxViewModel
    {
        private Zombie _han;
        public Zombie Han 
        {   
            get { return _han; }
            set { _han = value; RaisePropertyChanged(() => Han); }
        }

        public SecondViewModel()
        {
            Han = new Zombie()
                {
                    Name = "Han",
                    Location = new Location()
                        {
                            Lat = 51.4,
                            Lng = 0.4
                        },
                };
        }
    }
}
