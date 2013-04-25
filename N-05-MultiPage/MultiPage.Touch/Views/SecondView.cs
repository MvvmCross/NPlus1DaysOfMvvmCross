using System;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace MultiPage.Touch.Views
{
    [Register("SecondView")]
    public class SecondView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UniversalView();
            View.BackgroundColor = UIColor.Red;

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            Title = "Second";
        }
    }
}