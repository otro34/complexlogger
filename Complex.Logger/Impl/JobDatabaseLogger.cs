using System;
using System.Data.SqlClient;
using Complex.Logger.Interface;
using Complex.Logger.Model;

namespace Complex.Logger.Impl
{
    public class JobDatabaseLogger : IJobLogger
    {
        private readonly ISettingsExtractor _settingsExtractor;

        private readonly ILogLevelDeterminator _logLevelDeterminator;

        public JobDatabaseLogger(ISettingsExtractor settingsExtractor, ILogLevelDeterminator logLevelDeterminator)
        {
            _settingsExtractor = settingsExtractor;
            _logLevelDeterminator = logLevelDeterminator;
        }

        public void Log(string message, LogLevel logLevel)
        {
            if (!_logLevelDeterminator.AcceptedLogLevel(logLevel)) return;

            message = $"[{DateTime.Now}]{message}";

            var connString = _settingsExtractor.Get<string>("loggerConnectionString");

            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand("insert into Log (date,message,logLevel) values (getDate(),@message,@logLevel)");

                command.Parameters.AddWithValue("@message", message);

                command.Parameters.AddWithValue("@type", logLevel);
                try
                {
                    conn.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
