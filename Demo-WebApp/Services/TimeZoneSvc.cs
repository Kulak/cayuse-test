using System;
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
    public class TimeZoneSvc : ITimeZone
    {
        private static DateTime UnixTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        private readonly IConfig _config;

        public TimeZoneSvc(IConfig config)
        {
            _config = config;
        }

        public async Task<TimeZoneResponse> GetTimeAsync(string latitude, string longitude)
        {
            using (var client = new HttpClient()) {
                var nowSinceEpochSecs = DateTime.UtcNow.Subtract(UnixTime).TotalSeconds;
                var path = $"https://maps.googleapis.com/maps/api/timezone/json?location={latitude},{longitude}&timestamp={nowSinceEpochSecs}&key={_config.TimeZoneAppID}";
                var result = client.GetAsync(path).Result;
                if (result.StatusCode != HttpStatusCode.OK) {
                    // TODO: log details
                    throw new DataLoadExceptionException($"Failed to load time: {result.StatusCode}");
                }
                var body = await result.Content.ReadAsStringAsync();
                var tzResponse = JObject.Parse(body);
                return new TimeZoneResponse(tzResponse);
            }
        }

    } // end of class
}