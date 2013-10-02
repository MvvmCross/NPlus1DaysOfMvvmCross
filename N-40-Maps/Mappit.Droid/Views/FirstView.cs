using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging;
using Mappit.Core.ViewModels;

namespace Mappit.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxFragmentActivity
    {
        private Marker _helen;
        private Marker _keith;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            var viewModel = (FirstViewModel) ViewModel;

            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);

            var options = new MarkerOptions();
            options.SetPosition(new LatLng(viewModel.Keith.Location.Lat, viewModel.Keith.Location.Lng));
            options.SetTitle("Keith");
            _keith = mapFragment.Map.AddMarker(options);

            var options2 = new MarkerOptions();
            options2.SetPosition(new LatLng(viewModel.Helen.Location.Lat, viewModel.Helen.Location.Lng));
            options2.SetTitle("Helen");
            _helen = mapFragment.Map.AddMarker(options2);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(_keith)
               .For(m => m.Position)
               .To(vm => vm.Keith.Location)
               .WithConversion(new LocationToLatLngValueConverter(), null);
            set.Bind(_helen)
               .For(m => m.Position)
               .To(vm => vm.Helen.Location)
               .WithConversion(new LocationToLatLngValueConverter(), null);
            set.Apply();

        }
    }
}