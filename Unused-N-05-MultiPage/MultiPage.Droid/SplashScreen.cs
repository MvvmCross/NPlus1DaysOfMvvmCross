using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace MultiPage.Droid
{
    [Activity(Label = "MultiPage", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}