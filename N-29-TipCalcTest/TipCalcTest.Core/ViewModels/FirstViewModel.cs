using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using TipCalcTest.Core.Services;

namespace TipCalcTest.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private readonly ITipService _tipService;

        public FirstViewModel(ITipService tipService)
        {
            _tipService = tipService;
        }

        private double _subTotal;
        public double SubTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; RaisePropertyChanged(() => SubTotal); Update(); }
        }

        private int _generosity;
        public int Generosity
        {
            get { return _generosity; }
            set { _generosity = value; RaisePropertyChanged(() => Generosity); Update(); }
        }

        private void Update()
        {
            Tip =  _tipService.Calc(SubTotal, Generosity);
        }

        private double _tip;
        public double Tip
        {
            get { return _tip; }
            set { _tip = value; RaisePropertyChanged(() => Tip); }
        }

        public ICommand PayCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<PayViewModel>(new Dictionary<string, string>()
                    {
                        { "total", (Tip + SubTotal).ToString()},
                    }));
            }
        }
    }
}
