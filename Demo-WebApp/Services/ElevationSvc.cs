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
    public class ElevationSvc : IElevation
    {
        private readonly IConfig _config;
        private readonly ILogger _logger;

        public ElevationSvc(IConfig config, ILogger<ElevationSvc> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<ElevationResponse> GetElevationAsync(string latitude, string longitude)
        {
            var path = $"https://maps.googleapis.com/maps/api/elevation/json?locations={latitude},{longitude}&key={_config.GoogleAppID}";
            var response = await HttpClientUtils.GetJObjectAsync(path, _logger);
            return new ElevationResponse(response);
        }

    } // end of class
}