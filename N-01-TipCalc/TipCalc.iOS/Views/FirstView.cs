using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System.Drawing;
using TipCalc.Core.ViewModels;
using UIKit;

namespace TipCalc.iOS.Views
{
    public partial class FirstView : MvxViewController<FirstViewModel>
    {
        public FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            var label = new UILabel(new RectangleF(10, 0, 300, 40));
            label.Text = "SubTotal";
            Add(label);

            var subTotalTextField = new UITextField(new RectangleF(10, 40, 300, 40));
            Add(subTotalTextField);

            var label2 = new UILabel(new RectangleF(10, 80, 300, 40));
            label2.Text = "Generosity?";
            Add(label2);

            var slider = new UISlider(new RectangleF(10, 120, 300, 40));
            slider.MinValue = 0;
            slider.MaxValue = 100;
            Add(slider);

            var label3 = new UILabel(new RectangleF(10, 160, 300, 40));
            label3.Text = "Tip";
            Add(label3);

            var tipLabel = new UILabel(new RectangleF(10, 200, 300, 40));
            Add(tipLabel);

            var label4 = new UILabel(new RectangleF(10, 240, 300, 40));
            label4.Text = "Total";
            Add(label4);

            var totalLabel = new UILabel(new RectangleF(10, 280, 300, 40));
            Add(totalLabel);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(subTotalTextField).To(vm => vm.SubTotal);
            set.Bind(slider).To(vm => vm.Generosity);
            set.Bind(tipLabel).To(vm => vm.Tip);
            set.Bind(totalLabel).To(vm => vm.Total);
            set.Apply();
        }
    }
}
