using KittenView.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;

namespace KittenView.iOS.Views
{
    public partial class FirstView : MvxTableViewController<FirstViewModel>
    {
        public FirstView() : base("FirstView", null)
        {
        }

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
