using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Platform.Converters;
using MvvmCross.Core.ViewModels;

namespace BindMe.Core.ViewModels
{
    public class LenValueConverter : MvxValueConverter<string, int>
    {
        protected override int Convert(string value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return 0;
            return value.Length;
        }
    }

    public class StripValueConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var paramString = parameter as string;
            if (value == null || paramString == null)
                return value;

            return value.Replace(paramString, "");
        }
    }

    public class Person
    {
        public TitleResponse Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public enum TitleResponse
    {
        None,
        Mr,
        Dr,
        Mrs,
        Ms,
        Miss,
    }

    public class FirstViewModel 
		: MvxViewModel
    {
        private string _firstName;
        public string FirstName 
        {   
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged(() => FirstName); }
        }

        private string _lastName;
        public string LastName 
        {   
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged(() => LastName); }
        }

        private List<TitleResponse> _titles = new List<TitleResponse>()
                    {
                        TitleResponse.None,
                        TitleResponse.Mr,
                        TitleResponse.Dr,
                        TitleResponse.Mrs,
                        TitleResponse.Ms,
                        TitleResponse.Miss,
                    };
        public List<TitleResponse> Titles
        {
            get
            {
                return _titles;
            }
        }

        private TitleResponse _title;
        public TitleResponse Title 
        {   
            get { return _title; }
            set { _title = value; RaisePropertyChanged(() => Title); }
        }

        private bool _accepted;
        public bool Accepted 
        {   
            get { return _accepted; }
            set { _accepted = value; RaisePropertyChanged(() => Accepted); }
        }

        public ICommand AddCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        if (!Accepted)
                            return;

                        People.Add(new Person()
                            {
                                FirstName = FirstName,
                                LastName = LastName,
                                Title = Title
                            });

                        Title = TitleResponse.None;
                        FirstName = "";
                        LastName = "";
                        Accepted = false;
                    });
            }
        }

        private ObservableCollection<Person> _people = new ObservableCollection<Person>();

        public ObservableCollection<Person> People 
        {   
            get { return _people; }
            set { _people = value; RaisePropertyChanged(() => People); }
        }
    }
}
