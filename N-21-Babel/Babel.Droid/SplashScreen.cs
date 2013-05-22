using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace Babel.Droid
{
    [Activity(Label = "Babel.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}