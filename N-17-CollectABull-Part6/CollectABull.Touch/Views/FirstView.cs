using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace CollectABull.Touch.Views
{
    [Register("HomeView")]
    public class HomeView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            var addButton = new UIButton(new RectangleF(10, 10, 300, 40));
            Add(addButton);
            var listButton = new UIButton(new RectangleF(10, 50, 300, 40));
            Add(listButton);

            var set = this.CreateBindingSet<HomeView, Core.ViewModels.HomeViewModel>();
            set.Bind(addButton).To(vm => vm.AddCommand);
            set.Bind(listButton).To(vm => vm.ListCommand);
            set.Apply();
        }
    }
}