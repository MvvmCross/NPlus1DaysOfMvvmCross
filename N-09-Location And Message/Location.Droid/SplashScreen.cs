using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace Location.Droid
{
    [Activity(Label = "Location.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}