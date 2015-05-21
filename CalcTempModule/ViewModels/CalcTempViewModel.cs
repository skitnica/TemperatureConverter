using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Practices.Prism.Mvvm;
using CalcTempServices;
using Microsoft.Practices.Unity;


namespace CalcTempModule.ViewModels
{
    public class CalcTempViewModel : BindableBase
    {
        private double _inputTemperature;
        private double _result;
        private bool _calculateFahrenheit;
        private bool _calculateCelsius;
        private ICalcTempService _calcTempService;

        ICalcTempService CalcTempService
        {
            get { return _calcTempService; }
            set { _calcTempService = value; }
        }

        public CalcTempViewModel(ICalcTempService calcTempService)
        {
            CalcTempService = calcTempService;
            CalculateFahrenheit = true;
        }

        public double InputTemperature
        {
            get { return _inputTemperature; }
            set
            {
                _inputTemperature = value;
                ConvertTemperature();
                OnPropertyChanged( () => this.InputTemperature );
            }
        }

        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged( () => this.Result);
            }
        }

        public bool CalculateFahrenheit
        {
            get { return _calculateFahrenheit; }
            set
            {
                _calculateFahrenheit = value;
                ConvertTemperature();
                OnPropertyChanged( () => this.CalculateFahrenheit);
            }
        }

        public bool CalculateCelsius
        {
            get { return _calculateCelsius; }
            set
            {
                _calculateCelsius = value;
                ConvertTemperature();
                OnPropertyChanged( () => this.CalculateCelsius);
            }
        }
        
        private void ConvertTemperature()
        {
            if (CalculateFahrenheit)
                Result = CalcTempService.CalculateFahrenheit(InputTemperature);
            else
                Result = CalcTempService.CalculateCelsius(InputTemperature);
        }
    }
}
