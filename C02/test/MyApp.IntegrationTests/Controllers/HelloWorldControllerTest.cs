using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Xunit.Abstractions;

namespace MyApp.IntegrationTests.Controllers;

public class HelloWorldControllerTest : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly HttpClient _httpClient;

    public HelloWorldControllerTest(WebApplicationFactory<Startup> webApplicationFactory)
    {
        _httpClient = webApplicationFactory.CreateClient();
    }

    public class Hello : HelloWorldControllerTest
    {
        private readonly ITestOutputHelper _logger;

        public Hello(WebApplicationFactory<Startup> webApplicationFactory, ITestOutputHelper logger)
            : base(webApplicationFactory)
        {
            _logger = logger;
        }

        [Fact]
        public async Task Should_respond_a_status_200_OK()
        {
            // Act
            var result = await _httpClient.GetAsync("/");
            var data = await result.Content.ReadAsStringAsync();
            _logger.WriteLine($"GetData:{data}");
            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task Should_respond_hello_world()
        {
            // Act
            var result = await _httpClient.GetAsync("/");

            // Assert
            var contentText = await result.Content.ReadAsStringAsync();
            Assert.Equal("Hello World!", contentText);
        }
    }
}
