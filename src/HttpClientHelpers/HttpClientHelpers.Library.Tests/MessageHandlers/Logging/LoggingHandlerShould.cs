using FluentAssertions;
using HttpClientHelpers.Library.MessageHandlers.Logging;
using System.Net.Http;
using Xunit;

namespace HttpClientHelpers.Library.Tests.MessageHandlers.Logging
{
    public class LoggingHandlerShould
    {
        [Fact]
        public void ConstructWithoutParamerers() =>
            new LoggingHandler().Should().BeOfType<LoggingHandler>();

        [Fact]
        public void ConstructWithCustomLogger() =>
            new LoggingHandler(new ConsoleLogger(), LogLevel.Debug).Should().BeOfType<LoggingHandler>();

        [Fact]
        public void ConstructWithInnerHandler() =>
            new LoggingHandler(new HttpClientHandler()).Should().BeOfType<LoggingHandler>();

        [Fact]
        public void ConstructWithInnerHandlerAndCustomLogger() =>
            new LoggingHandler(new HttpClientHandler(), new ConsoleLogger(), LogLevel.Debug).Should().BeOfType<LoggingHandler>();
    }
}
