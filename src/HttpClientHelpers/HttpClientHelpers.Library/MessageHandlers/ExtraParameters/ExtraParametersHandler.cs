using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientHelpers.Library.MessageHandlers.ExtraParameters
{
    public class ExtraParametersHandler
        : HttpClientHandler
    {
        private readonly Dictionary<string, string> _additionalParameters;

        public ExtraParametersHandler(Dictionary<string, string> additionalParameters) =>
            _additionalParameters = additionalParameters;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // TODO: add parameters to querystring
            return base.SendAsync(request, cancellationToken);
        }
    }
}
