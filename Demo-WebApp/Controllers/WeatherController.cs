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
    public class WeatherController : ControllerBase
    {
        private readonly IWeather _weatherSvc;
        private readonly ILogger _logger;

        public WeatherController(IWeather weatherSvc, ILogger<WeatherController> logger)
        {
            _weatherSvc = weatherSvc;
            _logger = logger;
        }

        // example uri: /api/weather?zipcode=99037
        [Route("[action]")]
        [HttpGet]
        public async Task<object> ByZip(string zipcode)
        {
            try {
                return await _weatherSvc.WeatherByZipAsync(zipcode);
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

    }
}
