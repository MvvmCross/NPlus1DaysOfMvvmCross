using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cirrious.MvvmCross.FieldBinding;
using Cirrious.MvvmCross.ViewModels;

namespace BindMe.Core.ViewModels
{
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
        public readonly INC<string> FirstName = new NC<string>("");
        public readonly INC<string> LastName = new NC<string>("");
        public readonly INC<TitleResponse> Title = new NC<TitleResponse>();
        public readonly INC<bool> Accepted = new NC<bool>();

        public readonly ObservableCollection<Person> People = new ObservableCollection<Person>();

        public readonly List<TitleResponse> Titles = new List<TitleResponse>()
                    {
                        TitleResponse.None,
                        TitleResponse.Mr,
                        TitleResponse.Dr,
                        TitleResponse.Mrs,
                        TitleResponse.Ms,
                        TitleResponse.Miss,
                    };

        public void Add()
        {
            if (!Accepted.Value)
                return;

            People.Add(new Person()
                {
                    FirstName = FirstName.Value,
                    LastName = LastName.Value,
                    Title = Title.Value
                });

            Title.Value = TitleResponse.None;
            FirstName.Value = "";
            LastName.Value = "";
            Accepted.Value = false;
        }
    }
}
