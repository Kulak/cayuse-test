using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Demo_WebApp.Interfaces
{
    /// <summary>
    /// WeatherResponse is a wrapper to access currently required parameters
    /// in a statically safe manner.
    /// </summary>
    public class WeatherResponse {
        public dynamic Original { get; }

        public WeatherResponse(JObject anOriginal) {
            this.Original = anOriginal;
        }

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