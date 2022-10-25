using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ITJob.CommandHandler.Modules.AdvertisementModule;
using ITJob.Domain.Installer;
using ITJob.Repository.Installer;
using ITJob.Repository.SeedWorks;
using SAF.SSN.Kernel.CommandBus.Handling;
using SAF.SSN.Kernel.CommandBus.Installer;
using SAF.SSN.Kernel.Infrastructure.Configuration;

namespace ITJob.CommandHandler.Installer
{
    public class CommandHandlerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            DataProviderConfigurator.AddMappingFromAssemblyOf<MappingAssembelyFinder>();
            container.Register(Classes.FromThisAssembly().Pick().WithServiceAllInterfaces().LifestyleTransient());
             

            container.Install(new DomainModelInstaller());
            container.Install(new CommandBusInstaller());
            container.Install(new RepositoryInstaller());
        }
    }
}
