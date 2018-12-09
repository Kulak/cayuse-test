using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo_WebApp.Interfaces
{
    /// <summary>
    /// TimeZoneResponse is a wrapper to access currently required parameters
    /// in a statically safe manner.
    /// </summary>
    public class TimeZoneResponse {
        [JsonIgnore]
        public dynamic Original { get; }

        public TimeZoneResponse(JObject anOriginal) {
            this.Original = anOriginal;
        }

        public int DstOffset {
            get {
                return (int)Original.dstOffset;
            }
        }

        public int RawOffset {
            get {
                return (int)Original.rawOffset;
            }
        }

        public string Status {
            get {
                return Original.status;
            }
        }

        public string TimeZoneID {
            get {
                return Original.timeZoneId;
            }
        }

        public string TimeZoneName {
            get {
                return Original.timeZoneName;
            }
        }

    } // end of TimeZoneResponse class

    /// <summary>
    /// Methods must be thread safe due to potential object reuse in concurrent environment.
    /// </summary>
    public interface ITimeZone {
        Task<TimeZoneResponse> GetTimeAsync(string latitude, string longitude);
    }
   
}