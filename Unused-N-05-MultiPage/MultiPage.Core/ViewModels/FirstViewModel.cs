using Cirrious.MvvmCross.ViewModels;

namespace MultiPage.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; RaisePropertyChanged(() => Age); }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _goCommand;
        public System.Windows.Input.ICommand GoCommand
        {
            get
            {
                _goCommand = _goCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoGo);
                return _goCommand;
            }
        }

        private void DoGo()
        {
            ShowViewModel<SecondViewModel>();
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _goWithParametersCommand;
        public System.Windows.Input.ICommand GoWithParametersCommand
        {
            get
            {
                _goWithParametersCommand = _goWithParametersCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoGoWithParameters);
                return _goWithParametersCommand;
            }
        }

        private void DoGoWithParameters()
        {
            ShowViewModel<ThirdViewModel>(new { name = Name, age = Age });
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _withNavigationCommand;
        public System.Windows.Input.ICommand WithNavigationCommand
        {
            get
            {
                _withNavigationCommand = _withNavigationCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoWithNavigation);
                return _withNavigationCommand;
            }
        }

        private void DoWithNavigation()
        {
            // do action
            ShowViewModel<FourthViewModel>(new FourthViewModel.Navigation() { Name = Name, Age = Age });
        }
        
    }
}
