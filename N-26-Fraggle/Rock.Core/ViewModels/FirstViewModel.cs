using System.Windows.Input;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;

namespace Rock.Core.ViewModels
{
    public class LengthValueConverter 
        : MvxValueConverter<string, int>
    {
        protected override int Convert(string value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.Length;
        }
    }

    public class HomeViewModel
        :MvxViewModel
    {
        public ICommand First { get { return new MvxCommand(() => ShowViewModel<FirstViewModel>());}}
        public ICommand Second { get { return new MvxCommand(() => ShowViewModel<SecondViewModel>()); } }
    }
    public class FirstViewModel 
		: MvxViewModel
    {
        private SubViewModel _sub = new SubViewModel();
        public SubViewModel Sub
        {
            get { return _sub; }
            set { _sub = value; RaisePropertyChanged(() => Sub); }
        }
    }

    public class SecondViewModel
        : MvxViewModel
    {
        private SubViewModel _sub = new SubViewModel();
        public SubViewModel Sub
        {
            get { return _sub; }
            set { _sub = value; RaisePropertyChanged(() => Sub); }
        }
    }

    public class SubViewModel
        : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }
    }
}
