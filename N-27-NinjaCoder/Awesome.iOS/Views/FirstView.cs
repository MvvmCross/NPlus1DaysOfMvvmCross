// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the FirstView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Awesome.iOS.Views
{
    using System.Drawing;

    using Cirrious.MvvmCross.Binding.BindingContext;

    using Core.ViewModels;
    using MonoTouch.Foundation;
    using MonoTouch.UIKit;

    /// <summary>
    /// Defines the FirstView type.
    /// </summary>
    [Register("FirstView")]
    public class FirstView : BaseView
    {
        /// <summary>
        /// Views the did load.
        /// </summary>
        /// <summary>
        /// Called when the View is first loaded
        /// </summary>
        public override void ViewDidLoad()
        {
            this.View = new UIView() { BackgroundColor = UIColor.White };

            base.ViewDidLoad();

            UILabel uiLabel = new UILabel(new RectangleF(10, 10, 300, 40));
            View.AddSubview(uiLabel);
            UITextField uiTextField = new UITextField(new RectangleF(0, 50, 300, 40));
            View.AddSubview(uiTextField);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(uiLabel).To(vm => vm.MyProperty).WithConversion("Length");
            set.Bind(uiLabel).For("Tap").To(vm => vm.MyCommand);
            set.Bind(uiTextField).To(vm => vm.MyProperty);
            set.Apply();
        }
    }
}