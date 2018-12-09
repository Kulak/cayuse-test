using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Demo_WebApp.Interfaces;
using Newtonsoft.Json.Linq;

namespace Demo_WebApp.Services
{
    /// <summary>
    /// Methods are thread safe.
    /// </summary>
    public class WeatherSvc : IWeather
    {
        private readonly IConfig _config;

        public WeatherSvc(IConfig config)
        {
            _config = config;
        }

        public async Task<WeatherResponse> WeatherByZipAsync(string zipcode)
        {
            using (var client = new HttpClient()) {
                var path = $"http://api.openweathermap.org/data/2.5/weather?zip={zipcode},us&appid={_config.WeatherAppID}";
                var result = client.GetAsync(path).Result;
                if (result.StatusCode != HttpStatusCode.OK) {
                    // TODO: log details
                    throw new DataLoadExceptionException($"Failed to load weather: {result.StatusCode}");
                }
                var body = await result.Content.ReadAsStringAsync();
                var weather = JObject.Parse(body);
                return new WeatherResponse(weather);
            }
        }

    } // end of class
}