using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Models.City;
using WeatherApp.Models.Forecast;
using WeatherApp.Services.Interfaces;


namespace WeatherApp.Services.Implementations
{
    public class WeatherServiceTest: IWeatherService
    {
        public async Task<List<Forecast>> GetForecastsAsync(string citykey)
        {
            var result = new List<Forecast>();
            using (StreamReader stream = new StreamReader("forecastresponse.json"))
            {
                var readJson = await stream.ReadToEndAsync();
                result = JsonConvert.DeserializeObject<ForecastCollection>(readJson).DailyForecasts;
                
            };
            return result;
        }

        public async Task<List<City>> SearchCitiesAsync(string keyWord)
        {
            var result = new List<City>();
            using(StreamReader stream = new StreamReader("citiessearch.json"))
            {
                var readJson = await stream.ReadToEndAsync();
                var items = JsonConvert.DeserializeObject<List<City>>(readJson);
                result = items.Where(x=> x.LocalizedName.ToLower().Contains(keyWord.ToLower())).ToList();
               
            };
            return result;

        }
    }
}
