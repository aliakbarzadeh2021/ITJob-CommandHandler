using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ITJob.Advertisement.Api.Host.Resolver;
using Owin;

namespace ITJob.Advertisement.Api.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var bootstrap = new DependencyContainer();
            bootstrap.Start();

            var config = new HttpConfiguration
            {
                DependencyResolver = new ApiDependencyResolver(DependencyContainer.Container)
            };
            ApiMapConfig(config);

            appBuilder.UseWebApi(config);
        }

        public void ApiMapConfig(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
