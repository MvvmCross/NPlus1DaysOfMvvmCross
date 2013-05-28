using Cirrious.MvvmCross.Dialog.Touch;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.Touch.Platform;

namespace N_23_Dlg.Touch
{
	public class Setup : MvxTouchDialogSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
            : base(applicationDelegate, presenter)
		{
		}

		protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp ()
		{
			return new Core.App();
		}
	}
}