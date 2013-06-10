using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Fragging;
using Rock.Core.ViewModels;

namespace Rock.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxFragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            var sub = (SubFrag)SupportFragmentManager.FindFragmentById(Resource.Id.sub1);
            sub.ViewModel = ((FirstViewModel) ViewModel).Sub;

            var dub = (DubFrag)SupportFragmentManager.FindFragmentById(Resource.Id.dub1);
            dub.ViewModel = ((FirstViewModel)ViewModel).Sub;
        }
    }
}