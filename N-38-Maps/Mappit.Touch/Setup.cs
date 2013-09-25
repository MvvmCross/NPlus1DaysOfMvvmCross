using Mappit.Touch.Views;
using MonoTouch.UIKit;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;

namespace Mappit.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

        protected override void FillBindingNames(Cirrious.MvvmCross.Binding.BindingContext.IMvxBindingNameRegistry obj)
        {
            //obj.AddOrOverwrite(typeof(FourthView.RegionManager), "Center");
            base.FillBindingNames(obj);
        }

		protected override IMvxApplication CreateApp ()
		{
			return new Core.App();
		}
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
	}
}