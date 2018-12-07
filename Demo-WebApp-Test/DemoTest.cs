using System;
using System.Net.Http;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Demo_WebApp;
using System.Net;
using Xunit.Abstractions;

namespace Demo_WebApp_Test
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public UnitTest1(WebApplicationFactory<Startup> factory, ITestOutputHelper output) {
            _client = factory.CreateClient();
            _output = output;
        }

        [Fact]
        public async void ValuesTest()
        {
            var response = _client.GetAsync("/api/values").Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var body = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"body: {body}");
            Assert.Equal("[\"value1\",\"value2\"]", body);
        }
    }
}
