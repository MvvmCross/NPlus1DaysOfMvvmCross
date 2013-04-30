using Cirrious.MvvmCross.ViewModels;

namespace MultiPage.Core.ViewModels
{
    public class ThirdViewModel
        :MvxViewModel
    {
        public void Init(string question)
        {
            TheAnswer = "I don't know " + question;
        }

        private string _theAnswer;
        public string TheAnswer
        {
            get { return _theAnswer; }
            set { _theAnswer = value; RaisePropertyChanged(() => TheAnswer); }
        }
    }
}