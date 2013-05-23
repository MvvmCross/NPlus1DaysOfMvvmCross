using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;

namespace AndroidDemo.TouchUI
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : MvxApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		AndroidDemo_TouchUIViewController viewController;
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var setup = new Setup (this, window);
			setup.Initialize ();

			Mvx.Resolve<IMvxAppStart> ().Start ();

			window.MakeKeyAndVisible ();
			
			return true;
		}
	}

	public class Setup : MvxTouchSetup
	{
		public Setup (MvxApplicationDelegate appDelegate, UIWindow window)
			: base(appDelegate, window)
		{
			
		}

		protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp ()
		{
			return new Core.App ();
		}
	}
}

