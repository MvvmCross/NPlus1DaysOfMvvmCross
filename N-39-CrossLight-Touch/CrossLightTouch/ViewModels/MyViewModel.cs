using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using CrossLightTouch.Annotations;

namespace CrossLightTouch.ViewModels
{
    public class RelayCommand
        : ICommand
    {
        private Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
    public class MyViewModel
        : INotifyPropertyChanged
    {
        private string _firstName = "Fred";
        public string FirstName 
        {   
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged(); }
        }

        private string _secondName = "Bloggs";
        public string SecondName 
        {   
            get { return _secondName; }
            set { _secondName = value; RaisePropertyChanged(); }
        }

        public ICommand SwitchCommand
        {
            get { return new RelayCommand(() =>
                {
                    var temp = SecondName;
                    SecondName = FirstName;
                    FirstName = temp;
                });}
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
