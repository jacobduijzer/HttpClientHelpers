using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using HttpClientHelpers.Library.MessageHandlers.ExtraParameters;
using Refit;
using Xunit;

namespace HttpClientHelpersLibrary.IntegrationTests.MessageHandlers.ExtraParameters
{
    public class ExtraParametersHandlerShould : IClassFixture<CustomTestFixture>
    {
        private const string BASE_TEST_URL = "https://jsonplaceholder.typicode.com";
        private readonly Dictionary<string, string> _fakeDictionary;

        private readonly CustomTestFixture _fixture;

        public ExtraParametersHandlerShould(CustomTestFixture fixture)
        {
            _fixture = fixture;
            _fakeDictionary = new Dictionary<string, string>
            {
                { "userId", "1" }
            };
        }

        [Fact]
        public async Task CallApiWithExtraParameters()
        {
            var testApi = CreateTestClient(_fakeDictionary);
            var items = await testApi.GetPostsAsync().ConfigureAwait(false);
            items.Should().NotBeNullOrEmpty();
        }

        private ITestApi CreateTestClient(Dictionary<string, string> extraParameters)
        {
            var httpClient = new HttpClient(new ExtraParametersHandler(new HttpClientHandler(), extraParameters));
            httpClient.BaseAddress = new Uri(BASE_TEST_URL);
            return RestService.For<ITestApi>(httpClient);
        }
    }
}
