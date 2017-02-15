namespace TipCalc.Core.Services
{
    public interface ICalculationService
    {
        double Tip(double subTotal, double generosity);
    }
}
