[![Build Status](https://dev.azure.com/jacob0072/HttpClientHelpers/_apis/build/status/jacobduijzer.HttpClientHelpers?branchName=master)](https://dev.azure.com/jacob0072/HttpClientHelpers/_build/latest?definitionId=1&branchName=master)
# HttpClientHelpers
Library with helpers for HttpClient, Refit, Polly, etc

# Message Handlers

## Logging handler

Ever wanted to see what's happening under the hood of calls with the HttpClient? Simply add a logging handler to see what's going on.

```csharp
    var httpClient = new HttpClient(new LoggingHandler(new HttpClientHandler(), _mockLogger.Object, logLevel));
    httpClient.BaseAddress = new Uri(BASE_TEST_URL);


```

##  Bearer authentication

##  Bearer authentication with Refit

##  Add parameters to query string

This handler can be used to add custom parameters to every call. I used it to add a security token to every call without having to specify it everywhere in my code.
