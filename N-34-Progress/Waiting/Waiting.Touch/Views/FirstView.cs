using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MBProgressHUD;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Waiting.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        private BindableProgress _bindableProgress;

        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            _bindableProgress = new BindableProgress(View);

            var button = new UIButton(UIButtonType.RoundedRect);
            button.Frame = new  RectangleF(10, 10, 300, 40);
            button.SetTitle("Fetch", UIControlState.Normal);
            Add(button);
            var textField = new UITextField(new RectangleF(10, 50, 300, 40));
            Add(textField);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(button).To(vm => vm.FetchCommand);
            set.Bind(textField).To(vm => vm.IsBusy);
            set.Bind(_bindableProgress).For(b => b.Visible).To(vm => vm.IsBusy);
            set.Apply();
        }

        private void Foo()
        {
            var hud = new MTMBProgressHUD(View)
            {
                LabelText = "Waiting...",
                RemoveFromSuperViewOnHide = true
            };

            View.AddSubview(hud);

            hud.Show(animated: true);
            hud.Hide(animated: true, delay: 5);
        }
    }

    public class BindableProgress
    {
        private MTMBProgressHUD _progress;
        private UIView _parent;

        public BindableProgress(UIView parent)
        {
            _parent = parent;
        }

        public bool Visible
        {
                get { return _progress != null; }
            set
            {
                if (Visible == value)
                    return;

                if (value)
                {
                    _progress = new MTMBProgressHUD(_parent)
                    {
                        LabelText = "Waiting...",
                        RemoveFromSuperViewOnHide = true
                    };
                    _parent.AddSubview(_progress);
                    _progress.Show(true);
                }
                else
                {
                    _progress.Hide(true);
                    _progress = null;
                }
            }
        }
            
    }
}