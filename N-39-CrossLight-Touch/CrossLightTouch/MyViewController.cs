using System;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using CrossLightTouch.ViewModels;
using MonoTouch.UIKit;
using System.Drawing;

namespace CrossLightTouch
{
    public class MyViewController 
        : UIViewController
        , IMvxBindable
    {
        UIButton button;
        int numClicks = 0;
        float buttonWidth = 200;
        float buttonHeight = 50;

        public IMvxBindingContext BindingContext { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                BindingContext.ClearAllBindings();
            }

            base.Dispose(disposing);
        }

        public object DataContext
        {
            get { return BindingContext.DataContext; }
            set { BindingContext.DataContext = value; }
        }

        public MyViewController()
        {
            this.CreateBindingContext();
            DataContext = new MyViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            button = UIButton.FromType(UIButtonType.RoundedRect);

            button.Frame = new RectangleF(
                View.Frame.Width / 2 - buttonWidth / 2,
                View.Frame.Height / 2 - buttonHeight / 2,
                buttonWidth,
                buttonHeight);

            button.SetTitle("Click me", UIControlState.Normal);

            
            button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                UIViewAutoresizing.FlexibleBottomMargin;

            View.AddSubview(button);

            var textFirst = new UITextField(new RectangleF(10, 50, 300, 40));
            Add(textFirst);

            var textSecond = new UITextField(new RectangleF(10, 90, 300, 40));
            Add(textSecond);

            var label = new UILabel(new RectangleF(10, 130, 300, 40));
            Add(label);

            var set = this.CreateBindingSet<MyViewController, MyViewModel>();
            set.Bind(textFirst).To(vm => vm.FirstName);
            set.Bind(textSecond).To(vm => vm.SecondName);
            set.Bind(button).To(vm => vm.SwitchCommand);
            set.Bind(label).Described("FirstName + ' ' + SecondName");
            set.Apply();
        }

    }
}

