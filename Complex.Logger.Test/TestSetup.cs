using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Complex.Logger.Test
{
    public class TestSetup
    {
        public WindsorContainer GetContainer()
        {
            var container = new WindsorContainer();

            container.Install(FromAssembly.InThisApplication());

            return container;
        }
    }
}
