using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Mappit.Core.ViewModels;
using MonoTouch.CoreLocation;
using MonoTouch.MapKit;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Mappit.Touch.Views
{
    [Register("FourthView")]
    public class FourthView : MvxViewController
    {
        private RegionManager _regionManager;

        public override void ViewDidLoad()
        {
            var mapView = new MKMapView();
            View = mapView;

            base.ViewDidLoad();

            var firstViewModel = (FourthViewModel)ViewModel;
            _regionManager = new RegionManager(mapView);

            var button = new UIButton(UIButtonType.RoundedRect);
            button.Frame = new RectangleF(10, 10, 300, 40);
            button.SetTitle("move", UIControlState.Normal);
            Add(button);

            var lat = new UITextField(new RectangleF(10, 50, 130, 40));
            lat.KeyboardType = UIKeyboardType.DecimalPad;
            Add(lat);

            var lng = new UITextField(new RectangleF(160, 50, 130, 40));
            lng.KeyboardType = UIKeyboardType.DecimalPad;
            Add(lng);

            var set = this.CreateBindingSet<FourthView, Core.ViewModels.FourthViewModel>();
            set.Bind(button).To(vm => vm.UpdateCenterCommand);
            set.Bind(lat).To(vm => vm.Lat);
            set.Bind(lng).To(vm => vm.Lng);
            set.Bind(_regionManager).For(r => r.Center).To(vm => vm.Location);
            set.Apply();
        }

        public class RegionManager
        {
            private readonly MKMapView _mapView;

            public RegionManager(MKMapView mapView)
            {
                _mapView = mapView;
            }

            public Location Center
            {
                get { return new Location() { Lat = _mapView.CenterCoordinate.Latitude, Lng = _mapView.CenterCoordinate.Longitude}; }
                set
                {
                    _mapView.SetRegion(MKCoordinateRegion.FromDistance(
                            new CLLocationCoordinate2D(value.Lat, value.Lng),
                            20000,
                            20000), true);
                }
            }
        }
    }
}
