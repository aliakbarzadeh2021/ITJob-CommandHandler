using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using ITJob.Advertisement.Api.Host.Installer;
using Topshelf.Runtime.Windows;

namespace ITJob.Advertisement.Api.Host.Resolver
{
    public class DependencyContainer
    {
        public static IWindsorContainer Container { get; private set; }

        public DependencyContainer()
        {
            Container = new WindsorContainer();
        }

        public void Start()
        {
            Container.Install(new ApiHostInstaller());
        }
        public static void Stop()
        {
            Container.Dispose();
        }
    }
}
