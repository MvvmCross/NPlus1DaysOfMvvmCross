using System;
using Cirrious.MvvmCross.Dialog.Touch;
using CrossUI.Touch.Dialog.Elements;
using MonoTouch.Foundation;

namespace N_23_Dlg.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxDialogViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

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