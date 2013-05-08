using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using KittenView.Core.ViewModels;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace KittenView.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxCollectionViewController
    {
		private bool _isInitialised;

		public FirstView ()
			: base(new UICollectionViewFlowLayout()
			{
				ItemSize = new SizeF(240, 400),
				ScrollDirection = UICollectionViewScrollDirection.Horizontal
			})
		{		
			_isInitialised = true;
			ViewDidLoad();
		}

        public sealed override void ViewDidLoad()
        {
			if (!_isInitialised)
				return;

            base.ViewDidLoad();

			CollectionView.RegisterNibForCell(KittenCollectionCell.Nib, KittenCollectionCell.Key);
			var source = new MvxCollectionViewSource(CollectionView, KittenCollectionCell.Key);
			CollectionView.Source = source;

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(source).To(vm => vm.Kittens);
            set.Apply();

            CollectionView.ReloadData();
        }
    }
}