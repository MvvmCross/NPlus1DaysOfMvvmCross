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
    [Register("FirstView")]
    public class FirstView : MvxViewController
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

            var firstViewModel = (FirstViewModel) ViewModel;
            var helenAnnotation = new ZombieAnnotation(firstViewModel.Helen);
            var keithAnnotation = new ZombieAnnotation(firstViewModel.Keith);

            mapView.AddAnnotation(helenAnnotation);
            mapView.AddAnnotation(keithAnnotation);

            mapView.SetRegion(MKCoordinateRegion.FromDistance(
                new CLLocationCoordinate2D(firstViewModel.Helen.Location.Lat, firstViewModel.Helen.Location.Lng),
                20000,
                20000), true);

            var button = new UIButton(UIButtonType.RoundedRect);
            button.Frame = new RectangleF(10, 10, 300, 40);
            button.SetTitle("move", UIControlState.Normal);
            Add(button);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(button).To(vm => vm.MoveCommand);
            set.Bind(helenAnnotation).For(a => a.Location).To(vm => vm.Helen.Location);
            set.Bind(keithAnnotation).For(a => a.Location).To(vm => vm.Keith.Location);
            set.Apply();
        }

        public class ZombieAnnotation : MKAnnotation
        {
            private readonly Zombie _zombie;

            public ZombieAnnotation(Zombie zombie)
            {
                _zombie = zombie;
            }

            public override CLLocationCoordinate2D Coordinate { get; set; }

            public Location Location
            {
                get { return new Location() {Lat = Coordinate.Latitude, Lng = Coordinate.Longitude}; }
                set
                {
                    UIView.Animate(1.0, () =>
                        {
                            WillChangeValue("coordinate");
                            Coordinate = new CLLocationCoordinate2D(value.Lat, value.Lng);
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

                var zombieAnnotation = (ZombieAnnotation) annotation;
                if (zombieAnnotation.Zombie.IsMale)
                {
                    //pin.PinColor = MKPinAnnotationColor.Purple;
                }
                else
                {
                    //pin.PinColor = MKPinAnnotationColor.Red;
                }

                return pin;
            }
        }        
    }
}
