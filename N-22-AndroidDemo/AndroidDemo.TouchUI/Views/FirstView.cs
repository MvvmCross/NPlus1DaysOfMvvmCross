using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using AndroidDemo.Core;

namespace AndroidDemo.TouchUI
{
	public partial class FirstView : MvxViewController
	{
		public FirstView () : base ("FirstView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

			var set = this.CreateBindingSet<FirstView, FirstViewModel> ();
			set.Bind (TheEdit2).To (vm => vm.Foo);
			set.Bind (TheLabel).To (vm => vm.Foo);
			set.Apply ();

		}
	}
}

