
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Books.Core.Services;

namespace Books.Touch
{
	public partial class BookCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("BookCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("BookCell");

		private readonly MvxImageViewLoader _loader;

		public BookCell (IntPtr handle) : base (handle)
		{
			_loader = new MvxImageViewLoader(() => MainImage);

			this.DelayBind(() => {
				var set = this.CreateBindingSet<BookCell, BookSearchItem> ();
				set.Bind(TitleLabel).To (item => item.volumeInfo.title);
				set.Bind (AuthorLabel).To (item => item.volumeInfo.authorSummary);
				set.Bind (_loader).To (item => item.volumeInfo.imageLinks.thumbnail); //smallThumbnail);
				set.Apply();
			});
		}
		
		public static BookCell Create ()
		{
			return (BookCell)Nib.Instantiate (null, null) [0];
		}
	}
}

