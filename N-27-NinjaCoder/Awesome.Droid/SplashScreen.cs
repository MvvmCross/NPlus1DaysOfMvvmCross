// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the SplashScreen type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Awesome.Droid
{
    using Android.App;

    using Cirrious.MvvmCross.Droid.Views;

    /// <summary>
    /// Defines the SplashScreen type.
    /// </summary>
    [Activity(Label = "Your App Name", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreen"/> class.
        /// </summary>
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}