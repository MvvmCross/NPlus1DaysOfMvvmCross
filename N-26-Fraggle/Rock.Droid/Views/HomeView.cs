using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Fragging;

namespace Rock.Droid.Views
{
    [Activity(Label = "View for HomeViewModel")]
    public class HomeView : MvxFragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
        }
    }
}