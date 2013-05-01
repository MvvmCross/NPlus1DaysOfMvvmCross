// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Books.Touch
{
	[Register ("BookCell")]
	partial class BookCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel AuthorLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel TitleLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView MainImage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AuthorLabel != null) {
				AuthorLabel.Dispose ();
				AuthorLabel = null;
			}

			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}

			if (MainImage != null) {
				MainImage.Dispose ();
				MainImage = null;
			}
		}
	}
}
