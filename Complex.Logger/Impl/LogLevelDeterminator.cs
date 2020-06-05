
using System.CodeDom;
using System.Collections.Generic;
using Complex.Logger.Interface;
using Complex.Logger.Model;

namespace Complex.Logger.Impl
{
    public class LogLevelDeterminator : ILogLevelDeterminator
    {
        private readonly ISettingsExtractor _settingsExtractor;

        public LogLevelDeterminator(ISettingsExtractor settingsExtractor)
        {
            _settingsExtractor = settingsExtractor;
        }

        public bool AcceptedLogLevel(LogLevel messageLogLevel)
        {
            var configuredLogLevels = _settingsExtractor.GetList("logLevels");

            return configuredLogLevels.Contains(messageLogLevel.ToString());

        }
    }
}
