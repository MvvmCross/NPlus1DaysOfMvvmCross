// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace CollectABull.Touch
{
	[Register ("AddView")]
	partial class AddView
	{
		[Outlet]
		MonoTouch.UIKit.UITextField CaptionText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField NotesText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton AddPictureButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SaveButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch LocationSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView MainImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CaptionText != null) {
				CaptionText.Dispose ();
				CaptionText = null;
			}

			if (NotesText != null) {
				NotesText.Dispose ();
				NotesText = null;
			}

			if (AddPictureButton != null) {
				AddPictureButton.Dispose ();
				AddPictureButton = null;
			}

			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}

			if (LocationSwitch != null) {
				LocationSwitch.Dispose ();
				LocationSwitch = null;
			}

			if (MainImageView != null) {
				MainImageView.Dispose ();
				MainImageView = null;
			}
		}
	}
}
