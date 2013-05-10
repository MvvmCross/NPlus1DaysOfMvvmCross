
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using MyApp.Core;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace MyApp.Touch
{
	public partial class FirstView : MvxViewController
	{
		public FirstView () : base ("FirstView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		
			var set = this.CreateBindingSet<FirstView, FirstViewModel>();
			set.Bind(MyLabel).To (vm => vm.Name);
			set.Bind (MyText).To (vm => vm.Name);
			set.Apply();
		}
	}
}

