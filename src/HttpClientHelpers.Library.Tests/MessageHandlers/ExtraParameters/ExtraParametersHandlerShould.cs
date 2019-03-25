using FluentAssertions;
using HttpClientHelpers.Library.MessageHandlers.ExtraParameters;
using System.Collections.Generic;
using Xunit;

namespace HttpClientHelpers.Library.Tests.MessageHandlers.ExtraParameters
{
    public class ExtraParametersHandlerShould
    {
        private readonly Dictionary<string, string> _fakeDictionary;

        public ExtraParametersHandlerShould() =>
            _fakeDictionary = new Dictionary<string, string>
            {
                { "testparam", "testvalue" }
            };

        [Fact]
        public void Construct() =>
            new ExtraParametersHandler(_fakeDictionary).Should().BeOfType<ExtraParametersHandler>();
    }
}
