using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;

namespace MyApp.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate app, IMvxTouchViewPresenter presenter)
			: base(app, presenter)
		{
		}

		protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp ()
		{
			return new Core.App();
		}
	}

}
