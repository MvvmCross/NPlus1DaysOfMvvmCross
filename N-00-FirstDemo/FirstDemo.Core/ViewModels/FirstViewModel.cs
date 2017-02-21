using MvvmCross.Core.ViewModels;

namespace FirstDemo.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); RaisePropertyChanged(() => FullName); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); RaisePropertyChanged(() => FullName); }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", _firstName, _lastName); }
        }
    }
}
