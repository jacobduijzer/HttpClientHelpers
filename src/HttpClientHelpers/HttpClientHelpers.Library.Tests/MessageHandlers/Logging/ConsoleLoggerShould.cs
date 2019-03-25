using Castle.Core.Logging;
using FluentAssertions;
using Xunit;

namespace HttpClientHelpers.Library.Tests.MessageHandlers.Logging
{
    public class ConsoleLoggerShould
    {
        [Fact]
        public void Construct() =>
            new ConsoleLogger().Should().BeOfType<ConsoleLogger>();
    }
}
