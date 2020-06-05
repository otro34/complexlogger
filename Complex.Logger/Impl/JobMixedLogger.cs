using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Complex.Logger.Interface;
using Complex.Logger.Model;

namespace Complex.Logger.Impl
{
    public class JobMixedLogger : IJobLogger
    {
        private readonly IJobLoggerFactory _jobLoggerFactory;

        private readonly ILogLevelDeterminator _logLevelDeterminator;

        public JobMixedLogger(IJobLoggerFactory jobLoggerFactory, ILogLevelDeterminator logLevelDeterminator)
        {
            _jobLoggerFactory = jobLoggerFactory;
            _logLevelDeterminator = logLevelDeterminator;
        }

        public void Log(string message, LogLevel logLevel)
        {
            if (!_logLevelDeterminator.AcceptedLogLevel(logLevel)) return;

            message = $"[{DateTime.Now}]{message}";

            var fileLogger = _jobLoggerFactory.Create(LogType.File);

            var databaseLogger = _jobLoggerFactory.Create(LogType.Database);

            var consoleLogger = _jobLoggerFactory.Create(LogType.Console);

            fileLogger.Log(message, logLevel);

            databaseLogger.Log(message, logLevel);

            consoleLogger.Log(message, logLevel);
        }
    }
}
