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
    [Register("SecondView")]
    public class SecondView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            var mapView = new MKMapView();
            mapView.Delegate = new MyDelegate();
            View = mapView;

            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var secondViewModel = (SecondViewModel)ViewModel;
            var hanAnnotation = new ZombieAnnotation(secondViewModel.Han);

            mapView.AddAnnotation(hanAnnotation);

            mapView.SetRegion(MKCoordinateRegion.FromDistance(
                new CLLocationCoordinate2D(secondViewModel.Han.Location.Lat, secondViewModel.Han.Location.Lng),
                20000,
                20000), true);

            var button = new UIButton(UIButtonType.RoundedRect);
            button.Frame = new RectangleF(10, 10, 300, 40);
            button.SetTitle("move", UIControlState.Normal);
            Add(button);

            var set = this.CreateBindingSet<SecondView, Core.ViewModels.SecondViewModel>();
            set.Bind(hanAnnotation).For(a => a.Location).To(vm => vm.Han.Location);
            set.Bind(button).For("Title").To(vm => vm.Han.Location);
            set.Apply();
        }

        public class ZombieAnnotation : MKAnnotation
        {
            private readonly Zombie _zombie;

            public ZombieAnnotation(Zombie zombie)
            {
                _zombie = zombie;
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

                    UIView.Animate(1.0, () =>
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
