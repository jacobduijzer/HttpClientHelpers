using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace HttpClientHelpers.Library.MessageHandlers.ExtraParameters
{
    public class ExtraParametersHandler
        : DelegatingHandler
    {
        private readonly Dictionary<string, string> _additionalParameters;

        public ExtraParametersHandler(HttpClientHandler innerHandler, Dictionary<string, string> additionalParameters)
            : base(innerHandler)
        {
            Guard.Against.NullOrEmpty(additionalParameters, nameof(additionalParameters));
            _additionalParameters = additionalParameters;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.RequestUri = new Uri(QueryParameterBuilder.CreateRequestUri(request.RequestUri.ToString(), _additionalParameters));
            return base.SendAsync(request, cancellationToken);
        }
    }
}
