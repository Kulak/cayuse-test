using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo_WebApp.Controllers
{
    /// <summary>
    /// LocationResponse aggregates data into one object (composite object).
    /// </summary>
    public class LocationResponse {
        public WeatherResponse WeatherResponse {get;set;}
        public TimeZoneResponse TimeZoneResponse {get;set;}
        public ElevationResponse ElevationResponse {get;set;}
    } // end of LocationResponse

    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IWeather _weatherSvc;
        private readonly ITimeZone _timeZoneSvc;
        private readonly IElevation _elevationSvc;

        public LocationController(ILogger<LocationController> logger, IWeather weatherSvc, ITimeZone timeZoneSvc, IElevation elevationSvc)
        {
            _logger = logger;
            _weatherSvc = weatherSvc;
            _timeZoneSvc = timeZoneSvc;
            _elevationSvc = elevationSvc;
        }

        // example uri: /api/location/WeatherByZip?zipcode=99037
        [Route("[action]")]
        [HttpGet]
        public async Task<WeatherResponse> WeatherByZip(string zipcode)
        {
            return await _weatherSvc.WeatherByZipAsync(zipcode);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<TimeZoneResponse> TimeZoneByZip(string zipcode)
        {
            var weather = await _weatherSvc.WeatherByZipAsync(zipcode);
            return await _timeZoneSvc.GetTimeAsync(weather.Latitude, weather.Longitude);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ElevationResponse> ElevationByZip(string zipcode)
        {
            var weather = await _weatherSvc.WeatherByZipAsync(zipcode);
            return await _elevationSvc.GetElevationAsync(weather.Latitude, weather.Longitude);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<LocationResponse> AllByZip(string zipcode)
        {
            var weather = await _weatherSvc.WeatherByZipAsync(zipcode);
            var tzTask = _timeZoneSvc.GetTimeAsync(weather.Latitude, weather.Longitude);
            var elevationTask = _elevationSvc.GetElevationAsync(weather.Latitude, weather.Longitude);
            Task.WaitAll(tzTask, elevationTask);
            var tzResponse = tzTask.Result;
            var elevationResponse = elevationTask.Result;
            return new LocationResponse() {
                WeatherResponse = weather,
                TimeZoneResponse = tzResponse,
                ElevationResponse = elevationResponse
            };
        }

        [Route("[action]/{zipcode}")]
        [HttpGet]
        public async Task<string> DescriptionByZip(string zipcode)
        {
            var all = await this.AllByZip(zipcode);
            var text = new StringBuilder();
            text.AppendFormat("At the location '{0}', ", all.WeatherResponse.City);
            text.AppendFormat("the temperature is {0}, ", all.WeatherResponse.MainTemperature);
            text.AppendFormat("the timezone is {0}, ", all.TimeZoneResponse.TimeZoneName);
            text.AppendFormat("the elevation is {0}.", all.ElevationResponse.FirstElevationAsStr);
            return text.ToString();
        }


    } // end of class
}
