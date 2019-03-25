using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HttpClientHelpers.Library.MessageHandlers.Logging;
using Moq;
using Refit;
using Xunit;

namespace HttpClientHelpersLibrary.IntegrationTests.MessageHandlers.Logging
{
    public class LoggingHandlerShould : IClassFixture<CustomTestFixture>
    {
        private readonly CustomTestFixture _fixture;
        private readonly Mock<ILogger> _mockLogger;

        public LoggingHandlerShould(CustomTestFixture fixture)
        {
            _fixture = fixture;
            _mockLogger = new Mock<ILogger>();
            _mockLogger.Setup(x => x.Log(It.IsAny<string>())).Verifiable();
        }

        [Fact]
        public async Task ReturnItems()
        {
            var items = await _fixture.TestApi.GetToDoListAsync().ConfigureAwait(false);
            items.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task NotUseLogger()
        {
            _mockLogger.Reset();

            var httpClient = new HttpClient(new LoggingHandler(new HttpClientHandler(), _mockLogger.Object, LogLevel.None));
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            var testApi = RestService.For<ITestApi>(httpClient);

            var items = await testApi.GetToDoListAsync().ConfigureAwait(false);

            _mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task UseLogger()
        {
            _mockLogger.Reset();

            var httpClient = new HttpClient(new LoggingHandler(new HttpClientHandler(), _mockLogger.Object, LogLevel.Debug));
            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            var testApi = RestService.For<ITestApi>(httpClient);

            var items = await testApi.GetToDoListAsync().ConfigureAwait(false);

            _mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.AtLeastOnce);
        }
    }
}
