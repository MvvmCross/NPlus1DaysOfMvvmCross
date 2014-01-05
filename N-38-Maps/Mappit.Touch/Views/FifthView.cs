using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Mappit.Core.ViewModels;
using MonoTouch.CoreLocation;
using MonoTouch.MapKit;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Mappit.Touch.Views
{
    [Register("FifthView")]
    public class FifthView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            var mapView = new MKMapView();
            View = mapView;

            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var regionManager = new RegionManager(mapView);
            mapView.Delegate = regionManager;

            var button = new UIButton(UIButtonType.RoundedRect);
            button.Frame = new RectangleF(10, 10, 300, 40);
            button.SetTitle("move", UIControlState.Normal);
            Add(button);


            var set = this.CreateBindingSet<FifthView, Core.ViewModels.FifthViewModel>();
            set.Bind(regionManager).For(r => r.TheLocation).To(vm => vm.Location);
            set.Bind(button).For("Title").To(vm => vm.Location);
            set.Apply();
        }

        public class RegionManager
            : MKMapViewDelegate
        {
            private readonly MKMapView _mapView;

            public RegionManager(MKMapView mapView)
            {
                _mapView = mapView;
            }

            public override void RegionChanged(MKMapView mapView, bool animated)
            {
                var handler = TheLocationChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }

            public event EventHandler TheLocationChanged;

            public Location TheLocation
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
