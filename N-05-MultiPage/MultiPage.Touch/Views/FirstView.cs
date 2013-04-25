using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MultiPage.Core.ViewModels;

namespace MultiPage.Touch.Views
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
            BackgroundColor = UIColor.Red;
        }
    }

    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UniversalView();
            View.BackgroundColor = UIColor.Black;

            base.ViewDidLoad();

            var textField = new UITextField(new RectangleF(10, 10, 300, 40));
            textField.TextColor = UIColor.White;
            textField.BackgroundColor = UIColor.DarkGray;
            Add(textField);

            var slider = new UISlider(new RectangleF(10, 50, 300, 40));
            slider.MaxValue = 100;
            Add(slider);

            var button1 = new UIButton(new RectangleF(10, 90, 300, 30));
            button1.SetTitle("Go Simple", UIControlState.Normal);
            Add(button1);

            var button2 = new UIButton(new RectangleF(10, 120, 300, 30));
            button2.SetTitle("Go Anonymous", UIControlState.Normal);
            Add(button2);

            var button3 = new UIButton(new RectangleF(10, 150, 300, 30));
            button3.SetTitle("Go Navigation", UIControlState.Normal);
            Add(button3);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(textField).To(vm => vm.Name);
            set.Bind(slider).To(vm => vm.Age);
            set.Bind(button1).To(vm => vm.GoCommand);
            set.Bind(button2).To(vm => vm.GoWithParametersCommand);
            set.Bind(button3).To(vm => vm.WithNavigationCommand);
            set.Apply();
        }
    }
}