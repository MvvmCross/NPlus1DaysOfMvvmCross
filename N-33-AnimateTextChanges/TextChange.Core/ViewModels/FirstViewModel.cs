using System.Threading;
using Cirrious.MvvmCross.ViewModels;

namespace TextChange.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private readonly Timer _timer;

        public FirstViewModel()
        {
            _timer = new System.Threading.Timer(OnTick, null, 1000, 1000);
        }

        private void OnTick(object state)
        {
            Counter++;
        }

        private int _counter;

        public int Counter 
        {   
            get { return _counter; }
            set { _counter = value; RaisePropertyChanged(() => Counter); }
        }
    }
}
