using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ITJob.EntityFramework.Read.Implement.Installer;
using ITJob.Repository.SeedWorks;
using SAF.SSN.Kernel.Infrastructure.Configuration;

namespace ITJob.QueryService.Implement.Installer
{
    public class QueryServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            DataProviderConfigurator.AddMappingFromAssemblyOf<MappingAssembelyFinder>();
            container.Install(new EntityFrameworkReadOnlyRepositoryInstaller());
            container.Register(Classes.FromThisAssembly().IncludeNonPublicTypes().Pick().WithServiceDefaultInterfaces().LifestyleTransient());
            ActiveMapper.Initialize();
        }
    }
}
