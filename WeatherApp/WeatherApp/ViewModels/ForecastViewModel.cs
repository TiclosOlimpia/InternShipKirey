
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using WeatherApp.Models;
using WeatherApp.Models.Forecast;

namespace WeatherApp.ViewModels
{
    public class ForecastViewModel
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public DailyForecast Day { get; set; }
        public DailyForecast Night { get; set; }
        public string Test { set; get; }

        #region Forecast Constructor

        //in design time
        public ForecastViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                Date = DateTime.Now.AddDays(1);
                Temperature = new Temperature()
                {
                    Minimum = new Range { Value = 23, Unit = "C", UnitType = 1 },
                    Maximum = new Range { Value = 33, Unit = "C", UnitType = 1 }
                };

         
            }       Test = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        #endregion
    }
}
