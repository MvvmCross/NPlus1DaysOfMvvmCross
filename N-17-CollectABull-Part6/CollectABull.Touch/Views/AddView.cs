
using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using CollectABull.Core.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;

namespace CollectABull.Touch
{
	public partial class AddView : MvxViewController
	{
		public AddView () : base ("AddView", null)
		{
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
            var set = this.CreateBindingSet<AddView, AddViewModel>();
            set.Bind(CaptionText).To(vm => vm.Caption);
            set.Bind(NotesText).To(vm => vm.Notes);
            set.Bind(AddPictureButton).To(vm => vm.AddPictureCommand);
            set.Bind(SaveButton).To(vm => vm.SaveCommand);
            set.Bind(LocationSwitch).To(vm => vm.LocationKnown);
            set.Bind(MainImageView).To(vm => vm.PictureBytes).WithConversion("InMemoryImage");
            set.Apply();

		    var g = new UITapGestureRecognizer(() =>
		        {
		            CaptionText.ResignFirstResponder();
		            NotesText.ResignFirstResponder();

		        });

            View.AddGestureRecognizer(g);
		}
	}
}

