
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models.City;
using WeatherApp.Models.Forecast;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services.Implementations
{
    public class WeatherService : IWeatherService
    {
        public readonly string API_KEY = Properties.Settings.Default.WeatherAPI;
        public readonly string BASE_URL = Properties.Settings.Default.forecastURL;
        public readonly string AUTOCOMPLETE_URL = Properties.Settings.Default.autocompleteURL;


        public async Task<List<Forecast>> GetForecastsAsync(string cityKey)
        {
            var forecasts = new List<Forecast>();

            var url = string.Format(BASE_URL, cityKey, API_KEY);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                forecasts = JsonConvert.DeserializeObject<ForecastCollection>(json).DailyForecasts;
            };

            return forecasts;
        }

        public async Task<List<City>> SearchCitiesAsync(string keyWord)
        {
            var cities = new List<City>();

            var url = string.Format(BASE_URL, keyWord, API_KEY);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json) ?? new List<City>();

            };

            return cities;
        }

        
    }
}
