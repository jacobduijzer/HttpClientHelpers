using System;
using System.Threading.Tasks;
using FluentAssertions;
using HttpClientHelpers.Library.MessageHandlers.RefitBearerAuthentication;
using Xunit;

namespace HttpClientHelpers.Library.Tests.MessageHandlers.RefitBearerAuthentication
{
    public class RefitBearerAuthenticationHandlerShould
    {
        private readonly Func<Task<string>> _fakeTokenFunc;

        public RefitBearerAuthenticationHandlerShould() =>
            _fakeTokenFunc = new Func<Task<string>>(() => Task.FromResult<string>("testtoken"));

        [Fact]
        public void Construct() =>
            new RefitBearerAuthenticationHandler(_fakeTokenFunc).Should().BeOfType<RefitBearerAuthenticationHandler>();
    }
}
