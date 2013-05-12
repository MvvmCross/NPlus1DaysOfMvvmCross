using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;

namespace CollectABull.Touch.Views
{
    [Register("ListView")]
    public class ListView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxSimpleTableViewSource(TableView, ListCell.Key);
            TableView.Source = source;

            var set = this.CreateBindingSet<ListView, Core.ViewModels.ListViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Apply();
        }
    }
}