
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Complex.Logger.Impl;
using Complex.Logger.Interface;

namespace Complex.Logger
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyInThisApplication().Pick().WithServiceAllInterfaces().Unless(x => x.Name.Equals("JobConsoleLogger") ||
                                                                                                                     x.Name.Equals("JobDatabaseLogger") ||
                                                                                                                     x.Name.Equals("JobFileLogger") ||
                                                                                                                     x.Name.Equals("JobMixedLogger")));
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Component.For<IJobLogger>().ImplementedBy<JobConsoleLogger>().Named("JobConsoleLogger"),
                Component.For<IJobLogger>().ImplementedBy<JobDatabaseLogger>().Named("JobDatabaseLogger"),
                Component.For<IJobLogger>().ImplementedBy<JobFileLogger>().Named("JobFileLogger"),
                Component.For<IJobLogger>().ImplementedBy<JobMixedLogger>().Named("JobMixedLogger"),
                Component.For<IJobLoggerFactory>().AsFactory(c => c.SelectedWith<JobLoggerSelector>()));
        }
    }
}
