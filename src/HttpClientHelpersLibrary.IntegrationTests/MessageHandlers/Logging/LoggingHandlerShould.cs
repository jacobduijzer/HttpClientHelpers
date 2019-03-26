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
        private const string BASE_TEST_URL = "https://jsonplaceholder.typicode.com";

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

            var testApi = CreateTestClient(LogLevel.None);

            var items = await testApi.GetToDoListAsync().ConfigureAwait(false);

            _mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task UseLoggerWhenLogLevelIsDebug()
        {
            _mockLogger.Reset();

            var testApi = CreateTestClient(LogLevel.Debug);

            var items = await testApi.GetToDoListAsync().ConfigureAwait(false);

            _mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [Fact]
        public async Task UseLoggerWhenLogLevelIsInformation()
        {
            _mockLogger.Reset();

            var testApi = CreateTestClient(LogLevel.Information);

            var items = await testApi.GetToDoListAsync().ConfigureAwait(false);

            _mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.AtLeastOnce);
        }

        private ITestApi CreateTestClient(LogLevel logLevel)
        {
            var httpClient = new HttpClient(new LoggingHandler(new HttpClientHandler(), _mockLogger.Object, logLevel));
            httpClient.BaseAddress = new Uri(BASE_TEST_URL);
            return RestService.For<ITestApi>(httpClient);
        }
    }
}
