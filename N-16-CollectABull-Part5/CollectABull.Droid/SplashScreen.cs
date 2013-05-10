using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace CollectABull.Droid
{
    [Activity(Label = "CollectABull.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}