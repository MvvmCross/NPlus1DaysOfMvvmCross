using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging;
using Mappit.Core.ViewModels;

namespace Mappit.Droid.Views
{
    [Activity(Label = "View for FifthViewModel")]
    public class FifthView : MvxFragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FifthView);

            var viewModel = (FifthViewModel) ViewModel;

            var mapFragment = (MyMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);

            mapFragment.ViewModel = ViewModel;
        }
    }
}