using Android.Content;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Injection.Core.ViewModels;

namespace Injection.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            // register a single instance of IScreenSize
            Mvx.RegisterSingleton<IScreenSize>(new DroidScreenSize());

            // alternatively use lazy:
            // Mvx.RegisterSingleton<IScreenSize>(() => new DroidScreenSize());

            // alternatively use dynamic:
            // Mvx.RegisterType<IScreenSize, DroidScreenSize>();
        }
    }
}