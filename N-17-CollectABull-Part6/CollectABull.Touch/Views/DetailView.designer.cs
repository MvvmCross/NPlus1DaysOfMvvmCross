// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace CollectABull.Touch
{
	[Register ("DetailView")]
	partial class DetailView
	{
		[Outlet]
		MonoTouch.UIKit.UILabel CaptionLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel NoteLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LocationLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView MainImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel DateTimeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton DeleteButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CaptionLabel != null) {
				CaptionLabel.Dispose ();
				CaptionLabel = null;
			}

			if (NoteLabel != null) {
				NoteLabel.Dispose ();
				NoteLabel = null;
			}

			if (LocationLabel != null) {
				LocationLabel.Dispose ();
				LocationLabel = null;
			}

			if (MainImageView != null) {
				MainImageView.Dispose ();
				MainImageView = null;
			}

			if (DateTimeLabel != null) {
				DateTimeLabel.Dispose ();
				DateTimeLabel = null;
			}

			if (DeleteButton != null) {
				DeleteButton.Dispose ();
				DeleteButton = null;
			}
		}
	}
}
