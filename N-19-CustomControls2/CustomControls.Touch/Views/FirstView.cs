using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Touch.Views;
using CustomControls.Touch.Controls;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace CustomControls.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;


            var label = new ShapeLabel(new RectangleF(10, 10, 300, 40));
            Add(label);
            var textField = new UITextField(new RectangleF(10, 50, 300, 40));
            Add(textField);
            var shapeView = new ShapeView(new RectangleF(60, 90, 200, 200));
            Add(shapeView);

            var picker = new UIPickerView();
            var pickerViewModel = new MvxPickerViewModel(picker);
            picker.Model = pickerViewModel;
            picker.ShowSelectionIndicator = true;
            textField.InputView = picker;

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(label).For(s => s.TheShape).To(vm => vm.Shape);
            set.Bind(textField).To(vm => vm.Shape);
            set.Bind(pickerViewModel).For(p => p.ItemsSource).To(vm => vm.List);
            set.Bind(pickerViewModel).For(p => p.SelectedItem).To(vm => vm.Shape);
            set.Bind(shapeView).For(s => s.TheShape).To(vm => vm.Shape);
            set.Apply();

            var g = new UITapGestureRecognizer(() => textField.ResignFirstResponder());
            View.AddGestureRecognizer(g);
        }
    }
}