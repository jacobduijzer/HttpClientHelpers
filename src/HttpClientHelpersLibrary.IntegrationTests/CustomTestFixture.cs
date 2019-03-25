using System;
using Refit;

namespace HttpClientHelpersLibrary.IntegrationTests
{
    public class CustomTestFixture : IDisposable
    {
        public readonly ITestApi TestApi;

        public CustomTestFixture()
        {
            TestApi = RestService.For<ITestApi>("https://jsonplaceholder.typicode.com");
        }

        public void Dispose()
        {
        }
    }
}
