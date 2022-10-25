using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ITJob.Advertisement.Api.Host.BusConfig;
using ITJob.Advertisement.Api.Host.SeedWorks;
using ITJob.CommandHandler.Installer;
using ITJob.QueryService.Implement.Installer;

namespace ITJob.Advertisement.Api.Host.Installer
{
    public class ApiHostInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            BusConfiguratorService.Configure();
            container.Install(new CommandHandlerInstaller());
            container.Install(new QueryServiceInstaller());

            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
            container.Register(Classes.FromThisAssembly().BasedOn<ApiControllerBase>().LifestyleTransient());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
        }
    }
}
