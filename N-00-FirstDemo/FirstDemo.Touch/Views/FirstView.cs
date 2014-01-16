using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using FirstDemo.Core.ViewModels;
using MonoTouch.CoreFoundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace FirstDemo.Touch.Views
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds)
            : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.White;
        }
    }

    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public FirstView()
        {
        }

        public override void ViewDidLoad()
        {
            View = new UniversalView();

            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var textEditFirst = new UITextField(new RectangleF(0, 0, 320, 40));
            Add(textEditFirst);

            var textEditSecond = new UITextField(new RectangleF(0, 50, 320, 40));
            Add(textEditSecond);

            var labelFull = new UILabel(new RectangleF(0, 100, 320, 40));
            Add(labelFull);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(textEditFirst).To(vm => vm.FirstName);
            set.Bind(textEditSecond).To(vm => vm.LastName);
            set.Bind(labelFull).To(vm => vm.FullName);
            set.Apply();
        }
    }
}