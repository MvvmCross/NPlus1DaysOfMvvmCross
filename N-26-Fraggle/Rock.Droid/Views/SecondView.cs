using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Fragging;
using Rock.Core.ViewModels;

namespace Rock.Droid.Views
{
    [Activity(Label = "View for SecondViewModel")]
    public class SecondView : MvxFragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SecondView);

            var s = new SubFrag();
            s.ViewModel = ((SecondViewModel) ViewModel).Sub;

            var d = new DubFrag();
            d.ViewModel = ((SecondViewModel)ViewModel).Sub;

            var trans = SupportFragmentManager.BeginTransaction();
            trans.Replace(Resource.Id.subframe1, s);
            trans.Commit();

            var trans2 = SupportFragmentManager.BeginTransaction();
            trans2.Replace(Resource.Id.dubframe1, d);
            trans2.Commit();

            var but1 = FindViewById<Button>(Resource.Id.but1);
            var but2 = FindViewById<Button>(Resource.Id.but2);
            but1.Click += (sender, args) =>
                {
                    var dNew = new DubFrag()
                        {
                            ViewModel = ((SecondViewModel) ViewModel).Sub
                        };
                    var trans3 = SupportFragmentManager.BeginTransaction();
                    trans3.Replace(Resource.Id.subframe1, dNew);
                    trans3.AddToBackStack(null);
                    trans3.Commit();
                };
            but2.Click += (sender, args) =>
            {
                var sNew = new SubFrag()
                {
                    ViewModel = ((SecondViewModel)ViewModel).Sub
                };
                var trans4 = SupportFragmentManager.BeginTransaction();
                trans4.Replace(Resource.Id.dubframe1, sNew);
                trans4.AddToBackStack(null);
                trans4.Commit();
            };
        }
    }
}