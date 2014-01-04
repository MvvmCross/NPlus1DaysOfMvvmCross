using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Books.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var textField = new UITextField(new RectangleF(10, 10, 300, 40));
            Add(textField);

            var tableView = new UITableView(new RectangleF(0, 50, 320, 500), UITableViewStyle.Plain);
            Add(tableView);

			// choice here:
			//
			//   for original demo use:
            //     var source = new MvxStandardTableViewSource(tableView, "TitleText");
			//
			//   or for prettier cells from XIB file use:
			//     tableView.RowHeight = 88;
			//     var source = new MvxSimpleTableViewSource(tableView, BookCell.Key, BookCell.Key);

			tableView.RowHeight = 88;
			var source = new MvxSimpleTableViewSource(tableView, BookCell.Key, BookCell.Key);
			tableView.Source = source;

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(textField).To(vm => vm.SearchTerm);
            set.Bind(source).To(vm => vm.Results);
            set.Apply();

            tableView.ReloadData();
        }
    }
}