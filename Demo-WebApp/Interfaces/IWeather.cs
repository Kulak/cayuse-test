using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo_WebApp.Interfaces
{
    /// <summary>
    /// WeatherResponse exposes only response params required by application.
    /// </summary>
    public class WeatherResponse : ResponseWrapper {
        public WeatherResponse(JObject anOriginal) : base(anOriginal) {}

        public string Latitude {
            get {
                return Original.coord.lat;
            }
        }

        public string Longitude {
            get {
                return Original.coord.lon;
            }
        }

    } // end of WeatherResponse class

    /// <summary>
    /// Methods must be thread safe due to potential object reuse in concurrent environment.
    /// </summary>
    public interface IWeather {
        Task<WeatherResponse> WeatherByZipAsync(string zipcode);
    }
   
}