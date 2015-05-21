using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CalcTempServices;

namespace CalcTempServicesTests
{
    [TestFixture]
    public class CalcTempServiceTests
    {
        [Test]
        public void CalculateFahrenheit()
        {
            var calcTempService = new CalcTempService();

            var fahrenheit = calcTempService.CalculateFahrenheit(0);
            Assert.AreEqual(32,fahrenheit);

            fahrenheit = calcTempService.CalculateFahrenheit(28);
            Assert.AreEqual(82.4,fahrenheit);

        }

        public void CalculateCelsius()
        {
            var calcTempService = new CalcTempService();

            var celsius = calcTempService.CalculateCelsius(0);
            Assert.AreEqual(-17.8, celsius);

            celsius = calcTempService.CalculateCelsius(45);
            Assert.AreEqual(7.2, celsius);
        }
    }
}
