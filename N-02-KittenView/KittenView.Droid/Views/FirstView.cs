using Android.App;
using Android.OS;
using KittenView.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace KittenView.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity<FirstViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}
