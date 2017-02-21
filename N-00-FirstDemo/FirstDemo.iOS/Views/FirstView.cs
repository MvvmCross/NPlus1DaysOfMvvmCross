using FirstDemo.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using System.Drawing;

namespace FirstDemo.iOS.Views
{
    public partial class FirstView : MvxViewController<FirstViewModel>
    {
        public FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

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
