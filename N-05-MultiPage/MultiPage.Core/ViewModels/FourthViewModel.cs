using Cirrious.MvvmCross.ViewModels;

namespace MultiPage.Core.ViewModels
{
    public class FourthViewModel
        : MvxViewModel
    {
        public class Navigation
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public void Init(Navigation navigation)
        {
            Name = navigation.Name;
            Age = navigation.Age;
        }

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
    }
}