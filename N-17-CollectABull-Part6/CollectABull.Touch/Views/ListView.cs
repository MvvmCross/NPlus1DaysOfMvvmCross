using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using CollectABull.Core.ViewModels;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace CollectABull.Touch.Views
{
    [Register("ListView")]
    public class ListView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxStandardTableViewSource(TableView, "TitleText Caption;ImageUrl ImagePath");
            TableView.Source = source;

            var set = this.CreateBindingSet<ListView, ListViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowDetailCommand);
            set.Apply();

            TableView.ReloadData();
        }
    }
}