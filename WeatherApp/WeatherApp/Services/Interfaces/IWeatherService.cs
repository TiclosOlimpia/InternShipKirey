
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models.City;
using WeatherApp.Models.Forecast;

namespace WeatherApp.Services.Interfaces
{
    public interface IWeatherService
    {
        /// <summary>
        /// Get the list of all forecasts from json file
        /// </summary>
        /// <returns></returns>
        Task<List<Forecast>> GetForecastsAsync(string cityKey);

        /// <summary>
        ///  Get the list of all cities based on the given string from json file 
        /// </summary>
        /// <returns></returns>
        Task<List<City>> SearchCitiesAsync(string keyWord);
    }
}
