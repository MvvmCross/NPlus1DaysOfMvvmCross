using System;
using System.Collections.Generic;
using System.Linq;
using CrossLightTouch.Framework;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CrossLightTouch
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;
        MyViewController viewController;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            MiniSetup.Instance.EnsureInit();

            window = new UIWindow(UIScreen.MainScreen.Bounds);

            viewController = new MyViewController();
            window.RootViewController = viewController;

            window.MakeKeyAndVisible();

            return true;
        }
    }
}

