using System.Dynamic;
using System.Threading.Tasks;
using Demo_WebApp.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
}