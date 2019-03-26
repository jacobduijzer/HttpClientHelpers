using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientHelpers.Library.MessageHandlers.BearerAuthentication
{
    public class BearerAuthenticationHandler
        : DelegatingHandler
    {
        private readonly Func<Task<string>> _getToken;

        public BearerAuthenticationHandler(Func<Task<string>> getToken) =>
            _getToken = getToken ?? throw new ArgumentNullException(nameof(getToken));

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var token = await _getToken().ConfigureAwait(false);
            //request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
