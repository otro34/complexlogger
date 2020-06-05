
using System.Collections.Generic;

namespace Complex.Logger.Interface
{
    public interface ISettingsExtractor
    {
        T Get<T>(string keyName);

        List<string> GetList(string keyName);
    }
}
