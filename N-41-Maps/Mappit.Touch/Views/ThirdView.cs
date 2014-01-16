using System;
using System.Drawing;
using Cirrious.CrossCore.WeakSubscription;
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
    // an abstract helper class

    [Register("ThirdView")]
    public class ThirdView : MvxViewController
    {
        public class ZombieManager : MvxAnnotationManager
        {
            public ZombieManager(MKMapView mapView) 
                : base(mapView)
            {
            }

            protected override MKAnnotation CreateAnnotation(object item)
            {
                return new ZombieAnnotation(item as Zombie);
            }
        }

        private ZombieManager _zombieManager;

        public override void ViewDidLoad()
        {
            var mapView = new MKMapView();
            mapView.Delegate = new MyDelegate();
            View = mapView;

            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var thirdViewModel = (ThirdViewModel)ViewModel;
            _zombieManager = new ZombieManager(mapView);

            mapView.SetRegion(MKCoordinateRegion.FromDistance(
                new CLLocationCoordinate2D(51.4, 0.4),
                50000,
                50000), true);

            var set = this.CreateBindingSet<ThirdView, Core.ViewModels.ThirdViewModel>();
            set.Bind(_zombieManager).For(z => z.ItemsSource).To(vm => vm.Yarp);
            set.Apply();
        }

        public class ZombieAnnotation : MKAnnotation
        {
            private readonly Zombie _zombie;

            public ZombieAnnotation(Zombie zombie)
            {
                _zombie = zombie;
                UpdateLocation();
                _zombie.WeakSubscribe<Zombie>("Location", (s, e) => UpdateLocation());
            }

            private void UpdateLocation()
            {
                Location = _zombie.Location;
            }

            private CLLocationCoordinate2D _coordinate;
            public override CLLocationCoordinate2D Coordinate
            {
                get { return _coordinate; }
                set
                {
                    _coordinate = value;
                    var handler = LocationChanged;
                    if (handler != null)
                        handler(this, EventArgs.Empty);
                }
            }

            public event EventHandler LocationChanged;

            public Location Location
            {
                get { return new Location() {Lat = Coordinate.Latitude, Lng = Coordinate.Longitude}; }
                set
                {
                    if (value.Equals(Location))
                        return;

                    UIView.Animate(0.25, () =>
                        {
                            WillChangeValue("coordinate");
                            _coordinate = new CLLocationCoordinate2D(value.Lat, value.Lng);
                            DidChangeValue("coordinate");
                        });
                }
            }

            public Zombie Zombie
            {
                get { return _zombie; }
            }
        }

        public class MyDelegate : MKMapViewDelegate
        {
            public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, NSObject annotation)
            {
                var pin = (MKAnnotationView)mapView.DequeueReusableAnnotation("zombie");
                if (pin == null)
                {
                    pin = new MKAnnotationView(annotation, "zombie");
                    pin.Image = UIImage.FromFile("zombie.png");
                    pin.CenterOffset = new PointF(0, -30);
                }
                else
                {
                    pin.Annotation = annotation;
                }

                pin.Draggable = true;

                return pin;
            }
        }        
    }
}
