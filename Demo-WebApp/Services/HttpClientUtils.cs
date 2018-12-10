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
    public static class HttpClientUtils
    {
        public static async Task<JObject> GetJObjectAsync(string path, ILogger logger = null)
        {
            using (var client = new HttpClient()) {
                var result = client.GetAsync(path).Result;
                if (result.StatusCode != HttpStatusCode.OK) {
                    if (logger != null) {
                        logger.LogError("HTTP Client call to path {0} failed with {1}", path, result.Content);
                    }
                    throw new DataLoadException($"Failed REST API call: {result.StatusCode}");
                }
                var body = await result.Content.ReadAsStringAsync();
                var response  = JObject.Parse(body);
                return response;
            }
        }

    } // end of class
}