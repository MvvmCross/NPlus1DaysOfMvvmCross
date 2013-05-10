using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace CollectABull.Droid.Views
{
    [Activity(Label = "Detail")]
    public class DetailView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DetailView);
        }
    }
}