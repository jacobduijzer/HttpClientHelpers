using System;
using System.Collections.Generic;
using System.Net.Http;
using FluentAssertions;
using HttpClientHelpers.Library.MessageHandlers.ExtraParameters;
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
            new ExtraParametersHandler(new HttpClientHandler(), _fakeDictionary).Should().BeOfType<ExtraParametersHandler>();

        [Fact]
        public void ThrowsExceptionWhenParameterIsNull() =>
            new Action(() => new ExtraParametersHandler(new HttpClientHandler(), null)).Should().Throw<ArgumentNullException>();

        [Fact]
        public void ThrowExceptionWhenParameterIsEmpty() =>
            new Action(() => new ExtraParametersHandler(new HttpClientHandler(), new Dictionary<string, string>())).Should().Throw<ArgumentException>();
    }
}
