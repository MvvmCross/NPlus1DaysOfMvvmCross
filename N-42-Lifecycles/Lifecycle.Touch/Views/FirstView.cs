using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Lifecycle.Core.ViewModels;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Lifecycle.Touch.Views
{
    public abstract class BaseViewController : MvxViewController
    {
        protected IVisible VisibleViewModel
        {
            get { return base.ViewModel as IVisible; }
        }

        protected IKillable KillableViewModel
        {
            get { return base.ViewModel as IKillable; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var label = new UILabel(new RectangleF(10, 210, 300, 40));
            label.TextColor = UIColor.Black;
            label.BackgroundColor = UIColor.White;
            Add(label);

            var set = this.CreateBindingSet<BaseViewController, BaseViewModel>();
            set.Bind(label).To(vm => vm.Counter);
            set.Apply();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            VisibleViewModel.IsVisible(true);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            VisibleViewModel.IsVisible(false);
        }

        public override void DidMoveToParentViewController(UIViewController parent)
        {
            base.DidMoveToParentViewController(parent);
            if (parent == null)
                KillableViewModel.KillMe();
        }
    }

    [Register("FirstView")]
    public class FirstView : BaseViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
               EdgesForExtendedLayout = UIRectEdge.None;
			   
            var button = new UIButton(new RectangleF(10, 10, 300, 40));
            button.SetTitle("Go", UIControlState.Normal);
            button.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            Add(button);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(button).To(vm => vm.Go);
            set.Apply();
        }
    }
    [Register("SecondView")]
    public class SecondView : BaseViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView() { BackgroundColor = UIColor.White };
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var label = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(label);
            var textField = new UITextField(new RectangleF(10, 50, 300, 40));
            Add(textField);

            var set = this.CreateBindingSet<SecondView, Core.ViewModels.SecondViewModel>();
            set.Bind(label).To(vm => vm.Hello);
            set.Bind(textField).To(vm => vm.Hello);
            set.Apply();
        }
    }
}