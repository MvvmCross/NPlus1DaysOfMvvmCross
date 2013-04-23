using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace KittenView.Droid
{
    [Activity(Label = "KittenView", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}