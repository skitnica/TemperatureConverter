using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTempServices
{
    public class CalcTempService : ICalcTempService
    {
        public double CalculateFahrenheit(double celsius)
        {
            double fahrenheit = celsius * 9/5 + 32;

            return Math.Round(fahrenheit,1);
        }

        public double CalculateCelsius(double fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5 / 9;

            return celsius;
        }

    }
}
