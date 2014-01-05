using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Tabbed.Core.ViewModels;

namespace Tabbed.Touch.Views
{
    [Register("FirstView")]
    public sealed class FirstView : MvxTabBarViewController
    {
        public FirstView()
        {
            // need this additional call to ViewDidLoad because UIkit creates the view before the C# hierarchy has been constructed
            ViewDidLoad();
        }

        protected FirstViewModel FirstViewModel
        { get { return base.ViewModel as FirstViewModel; } }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            if (ViewModel == null)
                return;

            var viewControllers = new UIViewController[]
                                  {
                                    CreateTabFor("1", "home", FirstViewModel.Child1),
                                    CreateTabFor("2", "twitter", FirstViewModel.Child2),
                                    CreateTabFor("3", "favorites", FirstViewModel.Child3),
                                  };
            ViewControllers = viewControllers;
            CustomizableViewControllers = new UIViewController[] { };
            SelectedViewController = ViewControllers[0];
        }

        private int _createdSoFarCount = 0;

        private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
        {
            var controller = new UINavigationController();
            var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
            SetTitleAndTabBarItem(screen, title, imageName);
            controller.PushViewController(screen, false);
            return controller;
        }

        private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
        {
            screen.Title = title;
            screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle("Images/Tabs/" + imageName + ".png"),
                                                 _createdSoFarCount);
            _createdSoFarCount++;
        }

        public void ShowGrandChild(IMvxTouchView view)
        {
            var currentNav = SelectedViewController as UINavigationController;
            currentNav.PushViewController(view as UIViewController, true);
        }
    }


    public class Child1View : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView() { BackgroundColor = UIColor.DarkGray};
            base.ViewDidLoad();

            NavigationItem.BackBarButtonItem = new UIBarButtonItem()
                {
                    Title = "Kid1"
                };

            var label = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(label);
            var button = new UIButton(UIButtonType.RoundedRect);
            button.Frame = new RectangleF(10,50,300,40);
            button.SetTitle("Go", UIControlState.Normal);
            Add(button);

            this.CreateBinding(label).To<Child1ViewModel>(vm => vm.Foo).Apply();
            this.CreateBinding(button).To<Child1ViewModel>(vm => vm.GoCommand).Apply();
        }
    }
    public class Child2View : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView() { BackgroundColor = UIColor.Magenta };
            base.ViewDidLoad();

            var label = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(label);

            this.CreateBinding(label).To<Child2ViewModel>(vm => vm.Bar).Apply();
        }
    }
    public class Child3View : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView() { BackgroundColor = UIColor.Orange };
            base.ViewDidLoad();

            var label = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(label);

            this.CreateBinding(label).To<Child3ViewModel>(vm => vm.Oink).Apply();
        }
    }
    public class GrandChildView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView() { BackgroundColor = UIColor.Red };
            base.ViewDidLoad();

            Title = "Grand Child";
            var label = new UILabel(new RectangleF(10, 10, 300, 40));
            Add(label);

            this.CreateBinding(label).To<GrandChildViewModel>(vm => vm.Life).Apply();
        }
    }
}