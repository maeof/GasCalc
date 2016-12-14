using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasCalc
{
    public static class GasCalcFlow
    {
        public static decimal CalcFuelConsumption(decimal Distance, decimal FuelConsumption)
        {
            return Math.Round((FuelConsumption * Distance) / 100, 2);
        }

    }
}
