using System;
using System.Collections.Generic;
using FluentAssertions;
using HttpClientHelpers.Library.MessageHandlers.ExtraParameters;
using Xunit;

namespace HttpClientHelpers.Library.Tests.MessageHandlers.ExtraParameters
{
    public class QueryParameterBuilderShould
    {
        private readonly Dictionary<string, string> _fakeDictionary;

        public QueryParameterBuilderShould() =>
            _fakeDictionary = new Dictionary<string, string>
            {
                { "param1", "value1" }
            };

        [Fact]
        public void ReturnString() =>
            QueryParameterBuilder.CreateRequestUri("test", _fakeDictionary).Should().BeOfType<string>();

        [Fact]
        public void ThrowWhenInputUrlIsNull() =>
            new Action(() => QueryParameterBuilder.CreateRequestUri(null, _fakeDictionary)).Should().Throw<ArgumentNullException>();

        [Fact]
        public void ThrowWhenInputUrlIsEmpty() =>
            new Action(() => QueryParameterBuilder.CreateRequestUri("", _fakeDictionary)).Should().Throw<ArgumentException>();

        [Fact]
        public void ThrowWhenDictParameterIsNull() =>
            new Action(() => QueryParameterBuilder.CreateRequestUri("test", null)).Should().Throw<ArgumentNullException>();

        [Fact]
        public void ThrowWhenDictParameterIsEmpty() =>
            new Action(() => QueryParameterBuilder.CreateRequestUri("test", new Dictionary<string, string>())).Should().Throw<ArgumentException>();

        [Fact]
        public void ReturnUriWithExtraParameter() =>
            QueryParameterBuilder.CreateRequestUri("http://www.test.com/test?some=test", _fakeDictionary)
            .Should().Be("http://www.test.com/test?some=test&param1=value1");

        [Theory]
        [InlineData("http://www.google.com/12", "http://www.google.com/12?param1=value1")]
        [InlineData("http://www.google.com/12/12/123?", "http://www.google.com/12/12/123?param1=value1")]
        public void ReturnCorrectUrisForCases(string uri, string expected) =>
            QueryParameterBuilder.CreateRequestUri(uri, _fakeDictionary).Should().Be(expected);
    }
}
