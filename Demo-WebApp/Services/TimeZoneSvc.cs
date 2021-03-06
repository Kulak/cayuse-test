using System;
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
    public class TimeZoneSvc : ITimeZone
    {
        private static DateTime UnixTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        private readonly IConfig _config;
        private readonly ILogger _logger;

        public TimeZoneSvc(IConfig config, ILogger<TimeZoneSvc> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<TimeZoneResponse> GetTimeAsync(string latitude, string longitude)
        {
            var nowSinceEpochSecs = DateTime.UtcNow.Subtract(UnixTime).TotalSeconds;
            var path = $"https://maps.googleapis.com/maps/api/timezone/json?location={latitude},{longitude}&timestamp={nowSinceEpochSecs}&key={_config.GoogleAppID}";
            var response = await HttpClientUtils.GetJObjectAsync(path, _logger);
            return new TimeZoneResponse(response);
        }

    } // end of class
}