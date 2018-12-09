using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo_WebApp.Interfaces
{
    /// <summary>
    /// ResponseWrapper holds original response.
    /// The intension is to allow subclasses to provide direct access to most used data inside Original
    /// while still holding on original.
    /// </summary>
    public class ResponseWrapper {
        [JsonIgnore]
        public dynamic Original { get; }

        public ResponseWrapper(JObject anOriginal) {
            this.Original = anOriginal;
        }

    } // end of ResponseWrapper class
   
}