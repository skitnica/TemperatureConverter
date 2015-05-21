using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Mvvm;

namespace CalcTempModule.Views
{
    /// <summary>
    /// Interaction logic for CalcTempView.xaml
    /// </summary>
    public partial class CalcTempView : UserControl, IView
    {
        public CalcTempView()
        {
            InitializeComponent();

            base.Loaded += delegate
            {
                this.inputTemperature.Focus();
                this.inputTemperature.SelectAll();
            };
        }
               
    }
}
