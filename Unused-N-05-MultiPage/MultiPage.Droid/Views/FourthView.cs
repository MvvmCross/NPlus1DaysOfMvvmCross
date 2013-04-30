using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace MultiPage.Droid.Views
{
    [Activity(Label = "View for FourthViewModel")]
    public class FourthView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FourthView);
        }
    }
}