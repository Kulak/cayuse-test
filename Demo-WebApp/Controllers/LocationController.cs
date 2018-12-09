using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo_WebApp.Controllers
{
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
        public async Task<object> WeatherByZip(string zipcode)
        {
            try {
                return await _weatherSvc.WeatherByZipAsync(zipcode);
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Failed to get weather");
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<object> TimeZoneByZip(string zipcode)
        {
            try {
                var weather = await _weatherSvc.WeatherByZipAsync(zipcode);
                return await _timeZoneSvc.GetTimeAsync(weather.Latitude, weather.Longitude);
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Failed to get time zone.");
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<object> ElevationByZip(string zipcode)
        {
            try {
                var weather = await _weatherSvc.WeatherByZipAsync(zipcode);
                return await _elevationSvc.GetElevationAsync(weather.Latitude, weather.Longitude);
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return StatusCode(500, "Failed to get elevation.");
            }
        }

    } // end of class
}
