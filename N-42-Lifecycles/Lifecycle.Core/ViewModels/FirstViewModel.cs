using System.Threading;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;

namespace Lifecycle.Core.ViewModels
{
    public interface IVisible
    {
        void IsVisible(bool isVisible);
    }

    public interface IKillable
    {
        void KillMe();
    }

    public abstract class BaseViewModel
        : MvxViewModel
        , IVisible
        , IKillable
    {
        private Timer _timer;

        public BaseViewModel()
        {
            _timer = new Timer(Callback, null, 0, 0);
        }

        private void Callback(object state)
        {
            Counter++;
        }

        private int _counter;
        public int Counter 
        {   
            get { return _counter; }
            set { _counter = value; RaisePropertyChanged(() => Counter); }
        }

        public void IsVisible(bool isVisible)
        {
            if (isVisible)
                _timer.Change(1000,1000);
            else
                _timer.Change(0, 0);
        }

        public void KillMe()
        {
            Mvx.Trace("Killed: {0}", GetType().Name);
            _timer.Dispose();
        }
    }

    public class FirstViewModel
        : BaseViewModel
    {
        public ICommand Go
        {
            get { return new MvxCommand(() => ShowViewModel<SecondViewModel>());}
        }
    }

    public class SecondViewModel
        : BaseViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }
    }
}
