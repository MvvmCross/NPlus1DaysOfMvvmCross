using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging;
using Mappit.Core.ViewModels;

namespace Mappit.Droid.Views
{
    [Activity(Label = "View for FourthViewModel")]
    public class FourthView : MvxFragmentActivity
    {
        private CenterHelper _centerHelper;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FourthView);

            var viewModel = (FourthViewModel) ViewModel;

            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);

            _centerHelper = new CenterHelper(mapFragment.Map);

            var set = this.CreateBindingSet<FourthView, FourthViewModel>();
            set.Bind(_centerHelper)
               .For(m => m.Center)
               .To(vm => vm.Location)
               .WithConversion(new LocationToLatLngValueConverter(), null);
            set.Apply();
        }

        public class CenterHelper
        {
            private GoogleMap _map;

            public CenterHelper(GoogleMap map)
            {
                _map = map;
            }

            public LatLng Center
            {
                get { return _map.Projection.VisibleRegion.LatLngBounds.Center; }
                set
                {
                    var center = CameraUpdateFactory.NewLatLng(value);
                    _map.MoveCamera(center);
                }
            }
        }
    }
}