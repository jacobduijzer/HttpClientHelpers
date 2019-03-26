using System;
using System.Collections.Generic;
using System.Web;
using Ardalis.GuardClauses;

namespace HttpClientHelpers.Library.MessageHandlers.ExtraParameters
{
    public static class QueryParameterBuilder
    {
        public static string CreateRequestUri(string uri, Dictionary<string, string> parameters)
        {
            Guard.Against.NullOrEmpty(uri, nameof(uri));
            Guard.Against.NullOrEmpty(parameters, nameof(parameters));

            var uriBuilder = new UriBuilder(uri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var item in parameters)
            {
                query.Add(item.Key, item.Value);
            }
            uriBuilder.Query = query.ToString();
            if (uriBuilder.Uri.IsDefaultPort)
                uriBuilder.Port = -1;

            return uriBuilder.ToString();
        }
    }
}
