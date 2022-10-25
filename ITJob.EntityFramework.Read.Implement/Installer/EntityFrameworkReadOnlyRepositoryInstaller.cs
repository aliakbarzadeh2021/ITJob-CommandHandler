using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ITJob.EntityFramework.Read.Context.Interfaces;
using ITJob.EntityFramework.Read.Implement.Context.Implements;

namespace ITJob.EntityFramework.Read.Implement.Installer
{
    public class EntityFrameworkReadOnlyRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IReadOnlyRepository<>)).ImplementedBy(typeof(ReadOnlyRepository<>)).LifestyleTransient());

            ReadOnlyDataContext.ExecuteMigration();
        }
    }
}
