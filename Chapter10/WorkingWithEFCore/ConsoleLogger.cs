
using Microsoft.Extensions.Logging;

namespace Packt.Shared;


public class ConsoleLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new ConsoleLogger();
    }

    public void Dispose() { }
}

public class ConsoleLogger : ILogger
{
    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }
    public bool IsEnabled(LogLevel loglevel)
    {
        switch (loglevel)
        {
            case LogLevel.Trace:
            case LogLevel.Information:
            case LogLevel.None:
                return false;
            default: return true;
        }
    }

    public void Log<TState>(LogLevel logLevel,
 EventId eventId, TState state, Exception? exception,
 Func<TState, Exception, string> formatter)
    {
        // пишем в журнал уровень и идентификатор события
        Console.Write($"Level: {logLevel}, Event Id: {eventId.Id}");
        // выводим только существующее состояние или исключение
        if (state != null)
        {
            Console.Write($", State: {state}");
        }
        if (exception != null)
        {
            Console.WriteLine($", Exception: {exception.Message}");
        }
        Console.WriteLine();
    }
}
