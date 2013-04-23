using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace TipCalc.Droid
{
    [Activity(Label = "TipCalc", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}