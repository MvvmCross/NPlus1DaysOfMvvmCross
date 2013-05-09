// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MyApp.Touch
{
	[Register ("FirstView")]
	partial class FirstView
	{
		[Outlet]
		MonoTouch.UIKit.UILabel MyLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField MyText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MyLabel != null) {
				MyLabel.Dispose ();
				MyLabel = null;
			}

			if (MyText != null) {
				MyText.Dispose ();
				MyText = null;
			}
		}
	}
}
