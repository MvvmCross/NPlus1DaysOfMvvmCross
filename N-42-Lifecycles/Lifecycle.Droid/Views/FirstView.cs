using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Lifecycle.Core.ViewModels;

namespace Lifecycle.Droid.Views
{
    public abstract class BaseActivity
        : MvxActivity
    {
        protected IVisible VisibleViewModel
        {
            get { return base.ViewModel as IVisible; }
        }

        protected IKillable KillableViewModel
        {
            get { return base.ViewModel as IKillable; }
        }


        protected override void OnResume()
        {
            base.OnResume();
            VisibleViewModel.IsVisible(true);
        }

        protected override void OnPause()
        {
            base.OnPause();
            VisibleViewModel.IsVisible(false);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            KillableViewModel.KillMe();
        }
    }

    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : BaseActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
    [Activity(Label = "View for SecondViewModel")]
    public class SecondView : BaseActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SecondView);
        }
    }
}