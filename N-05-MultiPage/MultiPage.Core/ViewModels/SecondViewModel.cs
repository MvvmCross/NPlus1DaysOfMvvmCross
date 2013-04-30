using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.ViewModels;

namespace MultiPage.Core.ViewModels
{
    public class SecondViewModel
        : MvxViewModel
    {
        private string _name = "Second";
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(() => Name); }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _goThirdCommand;
        public System.Windows.Input.ICommand GoThirdCommand
        {
            get
            {
                _goThirdCommand = _goThirdCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoGoThird);
                return _goThirdCommand;
            }
        }

        private void DoGoThird()
        {
            ShowViewModel<ThirdViewModel>(new { question = "what time is it?"});
        }
    }
}
