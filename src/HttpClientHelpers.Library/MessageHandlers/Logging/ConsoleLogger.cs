using System;

namespace HttpClientHelpers.Library.MessageHandlers.Logging
{
    public class ConsoleLogger
        : ILogger
    {
        public void Log(string message) => Console.WriteLine($"{DateTime.Now}: {message}");
    }
}
