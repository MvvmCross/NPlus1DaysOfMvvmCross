using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using Mappit.Core.ViewModels;
using MonoTouch.CoreLocation;
using MonoTouch.MapKit;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Mappit.Touch.Views
{
    [Register("HomeView")]
    public class HomeView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.White;

            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var one = new UIButton(UIButtonType.RoundedRect);
            one.Frame = new RectangleF(10, 10, 300, 40);
            one.SetTitle("one", UIControlState.Normal);
            Add(one);
            var two = new UIButton(UIButtonType.RoundedRect);
            two.Frame = new RectangleF(10, 50, 300, 40);
            two.SetTitle("two", UIControlState.Normal);
            Add(two);
            var three = new UIButton(UIButtonType.RoundedRect);
            three.Frame = new RectangleF(10, 90, 300, 40);
            three.SetTitle("three", UIControlState.Normal);
            Add(three);
            var four = new UIButton(UIButtonType.RoundedRect);
            four.Frame = new RectangleF(10, 130, 300, 40);
            four.SetTitle("four", UIControlState.Normal);
            Add(four);
            var five = new UIButton(UIButtonType.RoundedRect);
            five.Frame = new RectangleF(10, 170, 300, 40);
            five.SetTitle("five", UIControlState.Normal);
            Add(five);

            var set = this.CreateBindingSet<HomeView, Core.ViewModels.HomeViewModel>();
            set.Bind(one).To(vm => vm.First);
            set.Bind(two).To(vm => vm.Second);
            set.Bind(three).To(vm => vm.Third);
            set.Bind(four).To(vm => vm.Fourth);
            set.Bind(five).To(vm => vm.Fifth);
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
