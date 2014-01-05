using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TextChange.Touch.Views
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

            var label = new UILabel(new RectangleF(10, 10, 300, 80));
            label.Font = UIFont.SystemFontOfSize(56f);
            Add(label);
            var label2 = new AnimatingLabel(new RectangleF(10, 90, 300, 80));
            label2.Font = UIFont.SystemFontOfSize(56f);
            Add(label2);
            

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(label).To(vm => vm.Counter);
            set.Bind(label2).For(l => l.AnimatingText).To(vm => vm.Counter);
            set.Apply();
        }
    }

    public class AnimatingLabel : UILabel
    {
        public AnimatingLabel(RectangleF frame)
            : base(frame)
        {            
        }

        public string AnimatingText
        {
            get { return base.Text; }
            set
            {
                UIView.Animate(
                    0.25,
                    () =>
                        {
                            Alpha = 0;
                        },
                        () =>
                            {
                                Text = value;
                                UIView.Animate(0.25, 
                                    () =>
                                        {
                                            Alpha = 1.0f;
                                        });
                            });
            }
        }
    }
}