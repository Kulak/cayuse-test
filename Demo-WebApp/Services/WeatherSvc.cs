using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Demo_WebApp.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Demo_WebApp.Services
{
    /// <summary>
    /// Methods are thread safe.
    /// </summary>
    public class WeatherSvc : IWeather
    {
        private readonly IConfig _config;
        private readonly ILogger _logger;

        public WeatherSvc(IConfig config, ILogger<WeatherSvc> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<WeatherResponse> WeatherByZipAsync(string zipcode)
        {
            var path = $"http://api.openweathermap.org/data/2.5/weather?zip={zipcode},us&appid={_config.WeatherAppID}";
            var response = await HttpClientUtils.GetJObjectAsync(path, _logger);
            return new WeatherResponse(response);
        }

    } // end of class
}