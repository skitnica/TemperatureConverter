using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTempServices
{
    public interface ICalcTempService
    {
        double CalculateFahrenheit(double celsius);
        double CalculateCelsius(double fahrenheit);
    }
}
