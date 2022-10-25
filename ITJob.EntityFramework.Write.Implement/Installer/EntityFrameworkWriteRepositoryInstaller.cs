using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ITJob.EntityFramework.Write.Context.Interfaces;
using ITJob.EntityFramework.Write.Implement.Context.Implements;

namespace ITJob.EntityFramework.Write.Implement.Installer
{
    public class EntityFrameworkWriteRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IContext>()
                    .ImplementedBy<DataContext>()
                    //.LifestylePerWebRequest()
                    .LifestyleScoped()
                //.LifestylePerThread()
            );
            container.Register(
                Component
                    .For(typeof(IRepository<>))
                    .ImplementedBy(typeof(Repository<>))
                    //.LifestylePerWebRequest()
                    .LifestyleScoped()
                //.LifestylePerThread()
            );

            DataContext.ExecuteMigration();
        }
    }
}
