using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Mappit.Droid.Views
{
    [Activity(Label = "View for HomeViewModel")]
    public class HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
        }
    }
}