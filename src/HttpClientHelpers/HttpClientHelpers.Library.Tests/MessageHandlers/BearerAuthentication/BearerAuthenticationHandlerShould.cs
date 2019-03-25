using FluentAssertions;
using HttpClientHelpers.Library.MessageHandlers.BearerAuthentication;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HttpClientHelpers.Library.Tests.MessageHandlers.BearerAuthentication
{
    public class BearerAuthenticationHandlerShould
    {
        private readonly Func<Task<string>> _fakeTokenFunc;

        public BearerAuthenticationHandlerShould() =>
            _fakeTokenFunc = new Func<Task<string>>(() => Task.FromResult<string>("testtoken"));

        [Fact]
        public void Construct() =>
            new BearerAuthenticationHandler(_fakeTokenFunc).Should().BeOfType<BearerAuthenticationHandler>();
    }
}
