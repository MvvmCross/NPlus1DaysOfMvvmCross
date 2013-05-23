using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Droid.Views;

namespace AndroidDemo.DroidUI
{
	public class Setup : MvxAndroidSetup
	{
		public Setup (Context appContext)
			: base(appContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App ();
		}
	}


	[Activity (Label = "AndroidDemo.DroidUI", MainLauncher = true)]
	public class FirstView : MvxActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
		}
	}
}


