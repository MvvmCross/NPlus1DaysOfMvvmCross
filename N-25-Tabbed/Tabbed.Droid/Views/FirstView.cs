using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Views;
using Tabbed.Core.ViewModels;

namespace Tabbed.Droid.Views
{
    [Activity(Label = "View for GrandChildViewModel")]
    public class GrandChildView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.GrandChildView);
        }
    }
    [Activity(Label = "View for Child1ViewModel")]
    public class Child1View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Child1View);
        }
    }
    [Activity(Label = "View for Child2ViewModel")]
    public class Child2View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Child2View);
        }
    }
    [Activity(Label = "View for Child3ViewModel")]
    public class Child3View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Child3View);
        }
    }

    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxTabActivity
    {
        protected FirstViewModel FirstViewModel
        {
            get { return base.ViewModel as FirstViewModel; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);


            TabHost.TabSpec spec;
            Intent intent;

            spec = TabHost.NewTabSpec("child1");
            spec.SetIndicator("1");
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child1));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("child2");
            spec.SetIndicator("2");
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child2));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("child3");
            spec.SetIndicator("3", Resources.GetDrawable(Resource.Drawable.Tab_Tweets));
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child3));
            TabHost.AddTab(spec);
        }
    }
}