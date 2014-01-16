
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
	public partial class DetailView : MvxViewController
	{
		public DetailView () : base ("DetailView", null)
		{
		}

        private MvxImageViewLoader _imageViewLoader;
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            _imageViewLoader = new MvxImageViewLoader(() => this.MainImageView);

            var set = this.CreateBindingSet<DetailView, DetailViewModel>();
            set.Bind(CaptionLabel).To(vm => vm.Item.Caption);
            set.Bind(NoteLabel).To(vm => vm.Item.Notes);
            set.Bind(LocationLabel).To(vm => vm.Item).WithConversion("ItemLocation");
            set.Bind(_imageViewLoader).To(vm => vm.Item.ImagePath);
            set.Bind(DateTimeLabel).To(vm => vm.Item.WhenUtc).WithConversion("TimeAgo");
            set.Bind(DeleteButton).To(vm => vm.DeleteCommand);
            set.Apply();
        }
	}
}

