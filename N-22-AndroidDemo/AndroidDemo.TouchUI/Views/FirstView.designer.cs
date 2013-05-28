// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace AndroidDemo.TouchUI
{
	[Register ("FirstView")]
	partial class FirstView
	{
		[Outlet]
		MonoTouch.UIKit.UITextField TheEdit2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel TheLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TheEdit2 != null) {
				TheEdit2.Dispose ();
				TheEdit2 = null;
			}

			if (TheLabel != null) {
				TheLabel.Dispose ();
				TheLabel = null;
			}
		}
	}
}
