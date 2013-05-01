using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace Books.Droid
{
    [Activity(Label = "Books.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}