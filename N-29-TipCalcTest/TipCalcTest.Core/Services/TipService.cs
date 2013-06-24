namespace TipCalcTest.Core.Services
{
    public class TipService : ITipService
    {
        public double Calc(double subTotal, int generosity)
        {
            return subTotal * generosity / 100.0;
        }
    }
}