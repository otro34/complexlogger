using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Complex.Logger.Interface;

namespace Complex.Logger.Impl
{
    public class SettingsExtractor : ISettingsExtractor
    {
        public T Get<T>(string keyName)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(keyName)) return default(T);

            var value = ConfigurationManager.AppSettings[keyName];

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public List<string> GetList(string keyName)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(keyName)) return default(List<string>);

            var value = ConfigurationManager.AppSettings[keyName].Split(',');

            return value.ToList();
        }
    }
}
