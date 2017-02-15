using MvvmCross.Core.ViewModels;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        private readonly ICalculationService _calculationService;

        public FirstViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
            _generosity = 20;
            _subTotal = 100;
            Recalc();
        }

        private double _generosity;
        public double Generosity
        {
            get { return _generosity; }
            set { SetProperty(ref _generosity, value); Recalc(); }
        }

        private double _subTotal;
        public double SubTotal
        {
            get { return _subTotal; }
            set { SetProperty(ref _subTotal, value); Recalc(); }
        }

        private double _tip;
        public double Tip
        {
            get { return _tip; }
            set { SetProperty(ref _tip, value); }
        }

        private double _total;
        public double Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }

        private void Recalc()
        {
            Tip = _calculationService.Tip(SubTotal, Generosity);
            Total = SubTotal + Tip;
        }
    }
}
