using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;

namespace N_23_Dlg.Droid
{
    [Activity(
		Label = "N_23_Dlg.Droid"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}