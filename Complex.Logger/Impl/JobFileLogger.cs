using System;
using System.IO;
using Complex.Logger.Interface;
using Complex.Logger.Model;

namespace Complex.Logger.Impl
{
    public class JobFileLogger : IJobLogger
    {
        private readonly ISettingsExtractor _settingsExtractor;
        private readonly ILogLevelDeterminator _logLevelDeterminator;

        public JobFileLogger(ISettingsExtractor settingsExtractor, ILogLevelDeterminator logLevelDeterminator)
        {
            _settingsExtractor = settingsExtractor;
            _logLevelDeterminator = logLevelDeterminator;
        }

        public void Log(string message, LogLevel logLevel)
        {
            if (!_logLevelDeterminator.AcceptedLogLevel(logLevel)) return;

            message = $"[{DateTime.Now}]{message}";

            var path = _settingsExtractor.Get<string>("logLocation");

            var fullPath = $"{path}LogFile{DateTime.Now.ToString("yyyymmdd")}.txt";

            if (!File.Exists(fullPath))
                using (var sw = File.CreateText(fullPath))
                {
                    sw.WriteLine(message);
                }

            using (var sw = File.AppendText(fullPath))
            {
                sw.WriteLine(message);
            }
        }
    }
}
