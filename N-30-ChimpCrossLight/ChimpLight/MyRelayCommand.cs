using System;
using System.Windows.Input;

namespace ChimpLight
{
    public class MyRelayCommand : ICommand
    {
        private Action _action;
        public MyRelayCommand(Action action)
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
}