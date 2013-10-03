using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Fragging.Fragments.EventSource;

namespace Mappit.Droid.Views
{
    public class MvxEventSourceMapFragment
           : SupportMapFragment
             , IMvxEventSourceFragment
    {
        public event EventHandler DisposeCalled;
        public event EventHandler<MvxValueEventArgs<MvxCreateViewParameters>> OnCreateViewCalled;
        public event EventHandler OnDestroyViewCalled;
        public event EventHandler<MvxValueEventArgs<Activity>> OnAttachCalled;

        public override void OnAttach(Activity activity)
        {
            OnAttachCalled.Raise(this, activity);
            base.OnAttach(activity);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            OnCreateViewCalled.Raise(this, new MvxCreateViewParameters(inflater, container, savedInstanceState));
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnDestroyView()
        {
            OnDestroyViewCalled.Raise(this);
            base.OnDestroyView();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeCalled.Raise(this);
            }
            base.Dispose(disposing);
        }
    }
}