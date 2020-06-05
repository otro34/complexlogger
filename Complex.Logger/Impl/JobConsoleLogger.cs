using System;
using Complex.Logger.Interface;
using Complex.Logger.Model;

namespace Complex.Logger.Impl
{
    public class JobConsoleLogger : IJobLogger
    {
        private readonly ILogLevelDeterminator _logLevelDeterminator;

        public JobConsoleLogger(ILogLevelDeterminator logLevelDeterminator)
        {
            _logLevelDeterminator = logLevelDeterminator;
        }

        public void Log(string message, LogLevel logLevel)
        {
            if (!_logLevelDeterminator.AcceptedLogLevel(logLevel)) return;

            message = $"[{DateTime.Now}]{message}";

            switch (logLevel)
            {
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }

            Console.WriteLine(DateTime.Now.ToShortDateString() + message);
        }
    }
}
