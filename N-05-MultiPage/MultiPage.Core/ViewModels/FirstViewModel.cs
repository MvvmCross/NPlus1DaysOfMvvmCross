using Cirrious.MvvmCross.ViewModels;

namespace MultiPage.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        private Cirrious.MvvmCross.ViewModels.MvxCommand _myCommand;
        public System.Windows.Input.ICommand MyCommand
        {
            get
            {
                _myCommand = _myCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoMyCommand);
                return _myCommand;
            }
        }

        private void DoMyCommand()
        {
            Hello = Hello + " World";
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _goSecondCommand;
        public System.Windows.Input.ICommand GoSecondCommand
        {
            get
            {
                _goSecondCommand = _goSecondCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoGoSecond);
                return _goSecondCommand;
            }
        }

        private void DoGoSecond()
        {
            ShowViewModel<SecondViewModel>();
        }
    }
}
