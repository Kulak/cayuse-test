using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Demo_WebApp.Interfaces
{
    /// <summary>
    /// Methods must be thread safe due to potential object reuse in concurrent environment.
    /// </summary>
    public interface IWeather {
        Task<JObject> WeatherByZipAsync(string zipcode);
    }
   
}