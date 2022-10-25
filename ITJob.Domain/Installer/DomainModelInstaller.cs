using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SAF.SSN.Kernel.DomainModel.Events;

namespace ITJob.Domain.Installer
{
    public class DomainModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().IncludeNonPublicTypes().Pick().WithServiceDefaultInterfaces().LifestyleTransient());

            if (!container.Kernel.HasComponent(typeof(IDomainEventHandlerFactory)))
                container.Register(Component.For<IDomainEventHandlerFactory>().ImplementedBy<DomainEventHandlerFactory>());
        }
    }
}
