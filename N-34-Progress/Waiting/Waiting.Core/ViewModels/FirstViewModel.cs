using System;
using System.Threading;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Waiting.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private DateTime? _whenToFinish;
        private Timer _timer;

        public FirstViewModel()
        {
            _timer = new System.Threading.Timer(OnTick, null, 1000, 1000);
        }

        private void OnTick(object state)
        {
            if (!_whenToFinish.HasValue)
                return;

            if (DateTime.UtcNow >= _whenToFinish.Value)
            {
                IsBusy = false;
                _whenToFinish = null;
            }
        }

        public ICommand FetchCommand
        {
            get { return new MvxCommand(() =>
                {
                    if (IsBusy)
                        return;

                    IsBusy = true;
                    _whenToFinish = DateTime.UtcNow.AddSeconds(3);
                });}
        }

        private bool _isBusy;
        public bool IsBusy 
        {   
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }

        private string _hello = "Hello MvvmCross";

        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}
    }
}
