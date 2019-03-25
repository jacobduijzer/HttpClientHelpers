using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientHelpers.Library.MessageHandlers.Logging
{
    public class LoggingHandler
        : DelegatingHandler
    {
        private readonly LogLevel _logLevel;
        private ILogger _logger;

        public LoggingHandler()
            : base()
        {
            InitializeComponent();
        }

        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            InitializeComponent();
        }

        public LoggingHandler(ILogger logger, LogLevel logLevel)
           : this()
        {
            _logger = logger;
            _logLevel = logLevel;
        }

        public LoggingHandler(HttpMessageHandler innerHandler, ILogger logger, LogLevel logLevel)
            : this(innerHandler)
        {
            _logger = logger;
            _logLevel = logLevel;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_logLevel == LogLevel.Debug && request.Content != null)
            {
                _logger.Log("Request:");
                _logger.Log(request.ToString());

                if (request.Content != null)
                    _logger.Log(await request.Content.ReadAsStringAsync());
                _logger.Log(Environment.NewLine);
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (_logLevel == LogLevel.Debug)
            {
                _logger.Log("Response:");
                _logger.Log(response.ToString());
                if (response.Content != null)
                    _logger.Log(await response.Content.ReadAsStringAsync());
                _logger.Log(Environment.NewLine);
            }

            return response;
        }

        private void InitializeComponent()
        {
            if (_logger == null)
                _logger = new ConsoleLogger();
        }
    }
}
