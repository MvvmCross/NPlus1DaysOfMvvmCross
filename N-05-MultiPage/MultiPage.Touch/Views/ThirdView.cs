using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MultiPage.Core.ViewModels;

namespace MultiPage.Touch.Views
{
    [Register("ThirdView")]
    public class ThirdView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UniversalView();
            View.BackgroundColor = UIColor.Green;

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            Title = "Third";

            var nameLabel = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(nameLabel);

            var ageLabel = new UILabel(new RectangleF(10, 50, 300, 40));
            Add(ageLabel);

            var set = this.CreateBindingSet<ThirdView, ThirdViewModel>();
            set.Bind(nameLabel).To(vm => vm.Name);
            set.Bind(ageLabel).To(vm => vm.Age);
            set.Apply();

        }
    }
}