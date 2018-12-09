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
    public class LocationTest
    {
        private readonly ITestOutputHelper _output;

        public LocationTest(ITestOutputHelper output) {
            _output = output;
        }

        [Fact]
        public async void WeatherByZip()
        {
            var configSvc = new TestConfigSvc();
            var weatherSvc = new WeatherSvc(configSvc, new XunitLogger<WeatherSvc>(_output));
            var weatherResponse = await weatherSvc.WeatherByZipAsync("99037");
            _output.WriteLine($"status: {weatherResponse.Original}");
            _output.WriteLine($"weather: {weatherResponse.Original.weather[0].main}");
            Assert.Equal("47.67", weatherResponse.Latitude);
            Assert.Equal("-117.2", weatherResponse.Longitude);
        }

        [Fact]
        public async void TimeZoneByLatLon()
        {
            var configSvc = new TestConfigSvc();
            var tzSvc = new TimeZoneSvc(configSvc, new XunitLogger<TimeZoneSvc>(_output));
            var response = await tzSvc.GetTimeAsync("47.67", "-117.2");
            _output.WriteLine($"status: {response.Original}");
            Assert.Equal(0, response.DstOffset);
            Assert.Equal(-28800, response.RawOffset);
            Assert.Equal("OK", response.Status);
            Assert.Equal("America/Los_Angeles", response.TimeZoneID);
            Assert.Equal("Pacific Standard Time", response.TimeZoneName);
        }

        [Fact]
        public async void ElevationByLatLon()
        {
            var configSvc = new TestConfigSvc();
            var elevationSvc = new ElevationSvc(configSvc, new XunitLogger<ElevationSvc>(_output));
            var response = await elevationSvc.GetElevationAsync("47.67", "-117.2");
            _output.WriteLine($"status: {response.Original}");
            Assert.Equal("606.084838867188", response.FirstElevationAsStr);
            Assert.Equal("4.77197599411011", response.FirstResolutionAsStr);
        }

    } // end of class
}
