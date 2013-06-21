using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace CustomBinding.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            var binaryEdit = new BinaryEdit(new RectangleF(10, 10, 300, 120));
            Add(binaryEdit);
            var textField = new UITextField(new RectangleF(10, 130, 300, 40));
            Add(textField);
            var nicerBinaryEdit = new NicerBinaryEdit(new RectangleF(10, 170, 300, 120));
            Add(nicerBinaryEdit);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            // to remove the need for `For("N28")` see Setup.FillBindingNames
            set.Bind(binaryEdit).For("N28").To(vm => vm.Counter);
            set.Bind(textField).To(vm => vm.Counter);
            // to remove the need for `For(be => be.MyCount)` see Setup.FillBindingNames
            set.Bind(nicerBinaryEdit).For(be => be.MyCount).To(vm => vm.Counter);
            set.Apply();

            var tap = new UITapGestureRecognizer(() => textField.ResignFirstResponder());
            View.AddGestureRecognizer(tap);
        }
    }
}