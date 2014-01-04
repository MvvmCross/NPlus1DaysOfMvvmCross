using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace MultiPage.Touch.Views
{
    [Register("SecondView")]
    public class SecondView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView() { BackgroundColor = UIColor.Red };
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var label = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(label);
            var button = new UIButton(UIButtonType.RoundedRect);
            button.SetTitle("Go Third", UIControlState.Normal);
            button.Frame = new RectangleF(10, 50, 300, 40);
            Add(button);

            var set = this.CreateBindingSet<SecondView, Core.ViewModels.SecondViewModel>();
            set.Bind(label).To(vm => vm.Name);
            set.Bind(button).To(vm => vm.GoThirdCommand);
            set.Apply();
        }
    }
}