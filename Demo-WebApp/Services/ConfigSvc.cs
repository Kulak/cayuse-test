using Demo_WebApp.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Demo_WebApp.Services
{
    public class ConfigSvc : IConfig
    {
        private readonly IConfiguration _configuration;

        public ConfigSvc(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string WeatherAppID => _configuration["CAYUSE_WeatherAppID"];
    }
}
