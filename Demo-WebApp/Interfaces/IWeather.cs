using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Demo_WebApp.Interfaces
{
    /// <summary>
    /// Retu
    /// </summary>
    public interface IWeather {
        Task<JObject> WeatherByZipAsync(string zipcode);
    }
   
}