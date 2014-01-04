
using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using CollectABull.Core.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;

namespace CollectABull.Touch
{
	public partial class HomeView : MvxViewController
	{
		public HomeView () : base ("HomeView", null)
		{
		}

	    private MvxImageViewLoader _imageViewLoader;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            _imageViewLoader = new MvxImageViewLoader(() => this.LatestImageView);
			
			// Perform any additional setup after loading the view, typically from a nib.
		    var set = this.CreateBindingSet<HomeView, HomeViewModel>();
		    set.Bind(_imageViewLoader).To(vm => vm.Latest.ImagePath);
		    set.Bind(LatestTitleLabel).To(vm => vm.Latest.Caption);
		    set.Bind(AddButton).To(vm => vm.AddCommand);
		    set.Bind(ListButton).To(vm => vm.ListCommand);
            set.Apply();
		}
	}
}

