using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.Views;

namespace ChimpLight
{
    [Activity(Label = "ChimpLight", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity, IMvxLayoutInflater
    {
        private MvxAndroidBindingContext _bindingContext;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            LightSetup.Instance.EnsureInitialized(ApplicationContext);

            _bindingContext = new MvxAndroidBindingContext(this, this, new PersonViewModel(this));

            // Set our view from the "main" layout resource
            var view = _bindingContext.BindingInflate(Resource.Layout.Main, null);
            SetContentView(view);
        }

        protected override void OnDestroy()
        {
            _bindingContext.ClearAllBindings();

            base.OnDestroy();
        }
    }
}

