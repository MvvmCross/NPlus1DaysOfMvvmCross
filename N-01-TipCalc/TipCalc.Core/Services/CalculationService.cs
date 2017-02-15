namespace TipCalc.Core.Services
{
    public class CalculationService
        : ICalculationService
    {
        public double Tip(double subTotal, double generosity)
        {
            return subTotal * generosity / 100.0;
        }
    }
}
