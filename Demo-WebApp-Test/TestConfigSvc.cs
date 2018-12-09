using System;
using Demo_WebApp.Interfaces;

namespace Demo_WebApp_Test
{
    class TestConfigSvc : IConfig
    {
        public string WeatherAppID => Environment.GetEnvironmentVariable("CAYUSE_WeatherAppID");

        public string GoogleAppID => Environment.GetEnvironmentVariable("CAYUSE_GoogleAppID");
    }
}