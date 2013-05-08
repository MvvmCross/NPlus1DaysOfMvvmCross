
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using KittenView.Core.Services;

namespace KittenView.Touch
{
	public partial class KittenCollectionCell : MvxCollectionViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("KittenCollectionCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("KittenCollectionCell");

		private readonly MvxImageViewLoader _loader;

		public KittenCollectionCell (IntPtr handle) 
			: base (string.Empty /* TODO - this isn't really needed - mvx bug */, handle)
		{
			_loader = new MvxImageViewLoader(() => MainImage);

			this.DelayBind(() => {
				var set = this.CreateBindingSet<KittenCollectionCell, Kitten>();
				set.Bind(NameLabel).To(kitten => kitten.Name);
				set.Bind (PriceLabel).To (kitten => kitten.Price);
				set.Bind (_loader).To (kitten => kitten.ImageUrl);
				set.Apply();
			});
		}
		
		public static KittenCollectionCell Create ()
		{
			return (KittenCollectionCell)Nib.Instantiate (null, null) [0];
		}
	}
}

