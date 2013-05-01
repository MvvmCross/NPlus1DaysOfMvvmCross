using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
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

            var textField = new UITextField(new RectangleF(10, 10, 300, 40));
            Add(textField);

            var tableView = new UITableView(new RectangleF(0, 50, 320, 500), UITableViewStyle.Plain);
            Add(tableView);
            var source = new MvxStandardTableViewSource(tableView, "TitleText");
            tableView.Source = source;

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(textField).To(vm => vm.SearchTerm);
            set.Bind(source).To(vm => vm.Results);
            set.Apply();

            tableView.ReloadData();
        }
    }
}