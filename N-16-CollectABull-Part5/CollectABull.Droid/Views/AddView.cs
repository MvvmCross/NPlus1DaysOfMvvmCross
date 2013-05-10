using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace CollectABull.Droid.Views
{
    [Activity(Label = "Add")]
    public class AddView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddView);
        }
    }
}