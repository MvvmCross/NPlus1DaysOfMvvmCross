using System;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging;
using Mappit.Core.ViewModels;

namespace Mappit.Droid.Views
{
    [Activity(Label = "View for SecondViewModel")]
    public class SecondView : MvxFragmentActivity
    {
        private MarkerWrapper _han;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SecondView);

            var viewModel = (SecondViewModel) ViewModel;

            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);

            var options = new MarkerOptions();
            options.SetPosition(new LatLng(viewModel.Han.Location.Lat, viewModel.Han.Location.Lng));
            options.SetTitle("Han");
            options.Draggable(true);
            var hanMarker = mapFragment.Map.AddMarker(options);

            _han = new MarkerWrapper(hanMarker);

            mapFragment.Map.MarkerDragEnd += (sender, args) =>
                {
                    _han.FirePositionChangedFromMap();
                };

            var set = this.CreateBindingSet<SecondView, SecondViewModel>();
            set.Bind(_han)
               .For(m => m.Position)
               .To(vm => vm.Han.Location)
               .WithConversion(new LocationToLatLngValueConverter(), null);
            set.Apply();

        }

        public class MarkerWrapper
        {
            private readonly Marker _marker;

            public MarkerWrapper(Marker marker)
            {
                _marker = marker;
            }

            public event EventHandler PositionChanged;

            public void FirePositionChangedFromMap()
            {
                PositionChanged.Raise(this);
            }

            public LatLng Position
            {
                get { return _marker.Position; }
                set { _marker.Position = value; }
            }
        }
    }
}