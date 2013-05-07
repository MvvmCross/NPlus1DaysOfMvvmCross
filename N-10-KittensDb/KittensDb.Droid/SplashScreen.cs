using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace KittensDb.Droid
{
    [Activity(Label = "KittensDb.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}