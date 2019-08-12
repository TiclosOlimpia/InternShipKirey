using System;

namespace WeatherApp.Models.Forecast
{
    public class Forecast
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public DailyForecast Day { get; set; }
        public DailyForecast Night { get; set; }
    }
}
