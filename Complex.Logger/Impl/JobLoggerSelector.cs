using System;
using Castle.Facilities.TypedFactory;
using Complex.Logger.Model;

namespace Complex.Logger.Impl
{
    public class JobLoggerSelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(System.Reflection.MethodInfo method, object[] arguments)
        {
            var type = (LogType) arguments[0];

            switch (type)
            {
                    case LogType.File:
                        return "JobFileLogger";
                    case LogType.Console:
                        return "JobConsoleLogger";
                    case LogType.Database:
                        return "JobDatabaseLogger";
                    case LogType.Mixed:
                        return "JobMixedLogger";
                    default:
                        throw new ApplicationException();
            }
        }

    }
}
