using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TipCalc.Core.Services
{
    public interface ICalculationService
    {
        double Tip(double subTotal, double generosity);
    }
}
