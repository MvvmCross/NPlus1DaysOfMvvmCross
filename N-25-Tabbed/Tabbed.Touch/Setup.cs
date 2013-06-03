using Cirrious.MvvmCross.Touch.Views.Presenters;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;
using Tabbed.Touch.Views;

namespace Tabbed.Touch
{
	public class Setup : MvxTouchSetup
	{
	    private MvxApplicationDelegate _applicationDelegate;
	    private UIWindow _window;

		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		    _applicationDelegate = applicationDelegate;
		    _window = window;
		}

		protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp ()
		{
			return new Core.App();
		}

        protected override IMvxTouchViewPresenter CreatePresenter()
        {
            return new MyPresenter(_applicationDelegate, _window);
        }
	}

    public class MyPresenter : MvxTouchViewPresenter
    {
        public MyPresenter(UIApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override UINavigationController CreateNavigationController(UIViewController viewController)
        {
            var navBar = base.CreateNavigationController(viewController);
            navBar.NavigationBarHidden = true;
            return navBar;
        }

        private FirstView _firstView;

        public override void Show(Cirrious.MvvmCross.Touch.Views.IMvxTouchView view)
        {
            if (view is FirstView)
            {
                _firstView = view as FirstView;
            }

            if (view is GrandChildView)
            {
                if (_firstView != null)
                {
                    _firstView.ShowGrandChild(view);
                }
                return;
            }

            base.Show(view);
        }
    }
}