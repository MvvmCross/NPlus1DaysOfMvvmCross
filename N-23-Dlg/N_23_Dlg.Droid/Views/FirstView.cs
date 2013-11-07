using System;
using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Dialog.Droid;
using Cirrious.MvvmCross.Dialog.Droid.Views;
using CrossUI.Droid.Dialog.Elements;

namespace N_23_Dlg.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxDialogActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Root = new RootElement("The Dialog")
                {
                    new Section("Strings")
                        {
                            new EntryElement("Hello").Bind(this, "Value Hello"),
                            new EntryElement("Hello2").Bind(this, "Value Hello2"),
                            new StringElement("Test").Bind(this, "Value Combined"),
                            new BooleanElement("T or F", false).Bind(this, "Value Option1"),
                            new BooleanElement("T or F:", true).Bind(this, "Value Option1"),
                        },
                    new Section("Dates")
                        {
                            new DateElement("The Date", DateTime.Today).Bind(this, "Value TheDate"),
                            new TimeElement("The Time", DateTime.Today).Bind(this, "Value TheDate"),
                            new StringElement("Actual").Bind(this, "Value TheDate")
                        }
                };
        }
    }
}