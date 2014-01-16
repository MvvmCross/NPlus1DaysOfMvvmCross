using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace MultiPage.Touch.Views
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

            var label = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(label);
            var textField = new UITextField(new RectangleF(10, 50, 300, 40));
            Add(textField);
            var button = new UIButton(UIButtonType.RoundedRect);
            button.SetTitle("Click Me", UIControlState.Normal);
            button.Frame = new RectangleF(10, 90, 300, 40);
            Add(button);
            var button2 = new UIButton(UIButtonType.RoundedRect);
            button2.SetTitle("Go Second", UIControlState.Normal);
            button2.Frame = new RectangleF(10, 130, 300, 40);
            Add(button2);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(label).To(vm => vm.Hello);
            set.Bind(textField).To(vm => vm.Hello);
            set.Bind(button).To(vm => vm.MyCommand);
            set.Bind(button2).To(vm => vm.GoSecondCommand);
            set.Apply();
        }
    }
}