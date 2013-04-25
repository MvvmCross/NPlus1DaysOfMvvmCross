using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MultiPage.Core.ViewModels;

namespace MultiPage.Touch.Views
{
    [Register("FourthView")]
    public class FourthView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UniversalView();
            View.BackgroundColor = UIColor.Blue;

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            Title = "Fourth";

            var nameLabel = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(nameLabel);

            var ageLabel = new UILabel(new RectangleF(10, 50, 300, 40));
            Add(ageLabel);

            var set = this.CreateBindingSet<FourthView, FourthViewModel>();
            set.Bind(nameLabel).To(vm => vm.Name);
            set.Bind(ageLabel).To(vm => vm.Age);
            set.Apply();

        }
    }
}