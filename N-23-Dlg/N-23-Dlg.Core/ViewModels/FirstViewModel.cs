using System;
using Cirrious.CrossCore.Converters;
using Cirrious.MvvmCross.ViewModels;

namespace N_23_Dlg.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private string _hello = "Hello";
        public string Hello
		{ 
			get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); RaisePropertyChanged(() => Combined); }
		}

        private string _hello2 = "MvvmCross";
        public string Hello2
        {
            get { return _hello2; }
            set { _hello2 = value; RaisePropertyChanged(() => Hello2); RaisePropertyChanged(() => Combined); }
        }

        public string Combined
        {
            get { return Hello + " " + Hello2; }
        }
        private DateTime _theDate = DateTime.Today;
        public DateTime TheDate
        {
            get { return _theDate; }
            set { _theDate = value; RaisePropertyChanged(() => TheDate); }
        }

        private bool _option1;
        public bool Option1
        {
            get { return _option1; }
            set { _option1 = value; RaisePropertyChanged(() => Option1); }
        }
        
    }

    public class TruthValueConverter : MvxValueConverter<bool, string>
    {
        protected override string Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value ? "yay" : "nay";
        }
    }

}
