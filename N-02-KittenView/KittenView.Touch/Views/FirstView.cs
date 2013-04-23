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
    public class FirstView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxStandardTableViewSource(TableView, "TitleText Name;ImageUrl ImageUrl");
            TableView.Source = source;

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(source).To(vm => vm.Kittens);
            set.Apply();

            TableView.ReloadData();
        }
    }
}