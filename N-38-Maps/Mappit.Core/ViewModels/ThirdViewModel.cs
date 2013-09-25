using System;
using System.Collections.ObjectModel;
using System.Threading;
using Cirrious.MvvmCross.ViewModels;

namespace Mappit.Core.ViewModels
{
    public class ThirdViewModel 
		: MvxViewModel
    {
        private ObservableCollection<Zombie> _yarp = new ObservableCollection<Zombie>();
        public ObservableCollection<Zombie> Yarp 
        {   
            get { return _yarp; }
            set { _yarp = value; RaisePropertyChanged(() => Yarp); }
        }

        private Timer _timer;
        private Random _random;

        public ThirdViewModel()
        {
            _random = new Random();
            _timer = new Timer(OnTick, null, 1000, 1000);
            AddZombie();
        }

        private void AddZombie()
        {
            var zombie = new Zombie()
                {
                    Name = "Zomby" + _yarp.Count,
                    Location = new Location()
                        {
                            Lat = 51.4,
                            Lng = 0.4
                        },
                };
            _yarp.Add(zombie);
        }

        private void OnTick(object state)
        {
            InvokeOnMainThread(() =>
                {
                    var p = _random.NextDouble();
                    if (p < 0.1)
                    {
                        AddZombie();
                    }
                    else
                    {
                        foreach (var zomby in Yarp)
                        {
                            var l1 = 0.01 * (_random.NextDouble() - 0.5);
                            var l2 = 0.01 * (_random.NextDouble() - 0.5);
                            zomby.Location = new Location()
                                {
                                    Lat = zomby.Location.Lat + l1,
                                    Lng = zomby.Location.Lng + l2,
                                };
                        }
                    }
                });
        }
    }
}
