using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Mappit.Core.ViewModels;

namespace Mappit.Droid.Views
{
    public class MyMapFragment
        : MvxMapFragment
    {
        private bool _bound;

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var toReturn = base.OnCreateView(inflater, container, savedInstanceState);

            CreateBinding(inflater);

            return toReturn;
        }

        public event EventHandler CenterChanged;

        private LatLng _center;
        public LatLng Center
        {
            get { return _center; }
            set
            {
                _center = value;    
                var center = CameraUpdateFactory.NewLatLng(value);
                Map.MoveCamera(center);
            }
        }

        private void CreateBinding(LayoutInflater inflater)
        {
            if (_bound)
                return;

            Map.CameraChange += MapOnCameraChange;
            this.EnsureBindingContextIsSet(inflater);

            this.DelayBind(() =>
                {
                    var set = this.CreateBindingSet<MyMapFragment, FifthViewModel>();
                    set.Bind(this).For(v => v.Center).To(vm => vm.Location).WithConversion(new LocationToLatLngValueConverter(), null);
                    set.Apply();
                });

            _bound = true;
        }

        private void MapOnCameraChange(object sender, GoogleMap.CameraChangeEventArgs cameraChangeEventArgs)
        {
            _center = cameraChangeEventArgs.P0.Target;
            CenterChanged.Raise(this);
        }
    }
}