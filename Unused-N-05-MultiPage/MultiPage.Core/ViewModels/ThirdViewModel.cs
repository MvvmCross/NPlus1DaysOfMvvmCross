using Cirrious.MvvmCross.ViewModels;

namespace MultiPage.Core.ViewModels
{
    public class ThirdViewModel
        : MvxViewModel
    {
        public void Init(string name, int age)
        {
            Name = name;
            Age = age;
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