using Complex.Logger.Interface;
using Complex.Logger.Model;
using NUnit.Framework;

namespace Complex.Logger.Test
{
    [TestFixture]
    public class JobLoggerIntegrationTests
    {
        [Test, Ignore("Usage Sample")]
        public void LogFile()
        {

            var setup = new TestSetup();

            var container = setup.GetContainer();

            var loggerFactory = container.Resolve<IJobLoggerFactory>();

            var logger = loggerFactory.Create(LogType.File);

            logger.Log("This is Ok.", LogLevel.Error);

        }

        [Test, Ignore("Usage Sample")]
        public void LogDatabase()
        {

            var setup = new TestSetup();

            var container = setup.GetContainer();

            var loggerFactory = container.Resolve<IJobLoggerFactory>();

            var logger = loggerFactory.Create(LogType.Database);

            logger.Log("This is Ok.", LogLevel.Warning);

        }

        [Test, Ignore("Usage Sample")]
        public void LogConsole()
        {

            var setup = new TestSetup();

            var container = setup.GetContainer();

            var loggerFactory = container.Resolve<IJobLoggerFactory>();

            var logger = loggerFactory.Create(LogType.Console);

            logger.Log("This is Ok.", LogLevel.Error);

        }
    }
}
