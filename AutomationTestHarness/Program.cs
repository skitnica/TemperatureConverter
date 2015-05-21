/*
This is just an example of using the Automation library.  This will be extended in due time to
be use specflow and nunit for behaviour driven test scripts etc.
*/
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace AutomationTestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nBegin WPF UIAutomation test run\n");
                // launch application
                Console.WriteLine("Starting Temperature Converter");
                Process p = null;
                //todo test if already running - use running version.
                p = Process.Start(@"..\..\..\CalcTemp\bin\debug\CalcTemp.exe");

                SpinWait.SpinUntil(() =>
                {
                    return p != null;
                }, TimeSpan.FromSeconds(10));


                // get reference to main Window control
                IntPtr windowHandle = p.MainWindowHandle;
                                
                AutomationElement desktopElement = AutomationElement.FromHandle(windowHandle);
                if (desktopElement == null)
                    throw new Exception("Unable to get Main Window");

                // 
                // test if tofahrenheit selected at startup
                Console.WriteLine("Finding toFahrenheit radioButton");

                //AutomationElement conversionControlElement = null;
                //conversionControlElement = desktopElement.FindFirst(TreeScope.Descendants,
                //    new PropertyCondition(AutomationElement.NameProperty, "TempConvertRegion"));

                //if (conversionControlElement == null)
                //    throw new Exception("Unable to find conversion Control element");
                
                AutomationElement toFahrenheit = null;
                toFahrenheit = desktopElement.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "toFahrenheit"));

                if (toFahrenheit == null)
                    throw new Exception("Unable to find toFahrenheit control");

                SelectionItemPattern selectionPattern = (SelectionItemPattern)toFahrenheit.GetCurrentPattern(SelectionItemPattern.Pattern);
                if (selectionPattern == null)
                    throw new Exception("selection pattern not found for radio button control");

                if (!selectionPattern.Current.IsSelected)
                    throw new Exception("To Fahrenheit not selected on startup");
                else
                    Console.WriteLine("Success! To Fahrenheit selected on startup");

                // manipulate application
                // check resulting state and determine pass/fail
                Console.WriteLine("\nEnd automation\n");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal: " + ex.Message);
            }
        }
    }
}
