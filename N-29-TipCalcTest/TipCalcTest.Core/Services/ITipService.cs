using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TipCalcTest.Core.Services
{
    public interface ITipService
    {
        double Calc(double subTotal, int generosity);
    }
}
