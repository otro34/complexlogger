using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Complex.Logger.Model;

namespace Complex.Logger.Interface
{
    public interface IJobLoggerFactory
    {
        IJobLogger Create(LogType type);
    }
}
