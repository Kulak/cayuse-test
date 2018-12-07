using System;
using System.Net.Http;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit.Abstractions;
using Demo_WebApp.Services;
using Demo_WebApp.Interfaces;

namespace Demo_WebApp_Test
{
    public class WeatherTest
    {
        private readonly ITestOutputHelper _output;

        public WeatherTest(ITestOutputHelper output) {
            _output = output;
        }

        [Fact]
        public async void ShowWeather()
        {
            var configSvc = new TestConfigSvc();
            var weatherSvc = new WeatherSvc(configSvc);
            dynamic weatherResult = await weatherSvc.WeatherByZipAsync("99037");
            _output.WriteLine($"status: {weatherResult}");
            _output.WriteLine($"weather: {weatherResult.weather[0].main}");
            Assert.Equal(1, weatherResult.weather.Count);
        }
    }
}
