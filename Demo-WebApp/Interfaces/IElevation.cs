using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Demo_WebApp.Interfaces
{
    /// <summary>
    /// ElevationResponse holds on original Google response and provides access to most important params.
    /// </summary>
    public class ElevationResponse : ResponseWrapper {

        /// <summary>
        /// Constructor that takes original JSON response from HTTPClient.
        /// </summary>
        /// <param name="anOriginal">
        /// Example Original Response:
        ///            {
        ///   "results": [
        ///     {
        ///       "elevation": 606.0848388671875,
        ///       "location": {
        ///         "lat": 47.67,
        ///         "lng": -117.2
        ///       },
        ///       "resolution": 4.7719759941101074
        ///     }
        ///   ],
        ///   "status": "OK"
        /// }
        /// </param>
        /// <returns></returns>
        public ElevationResponse(JObject anOriginal) : base(anOriginal) {}

        public string FirstElevationAsStr {
            get {
                if (Original.results.Count > 0) {
                    // WARN: conversion from float to string; loss of precision
                    return Original.results[0].elevation;
                }
                return "";
            }
        }

        public string FirstResolutionAsStr {
            get {
                if (Original.results.Count > 0) {
                    // WARN: conversion from float to string; loss of precision
                    return Original.results[0].resolution;
                }
                return "";
            }
        }

        public string Status {
            get { return Original.status; }
        }

    } // end of WeatherResponse class

    /// <summary>
    /// Methods must be thread safe due to potential object reuse in concurrent environment.
    /// </summary>
    public interface IElevation {
        Task<ElevationResponse> GetElevationAsync(string latitude, string longitude);
    }
   
}