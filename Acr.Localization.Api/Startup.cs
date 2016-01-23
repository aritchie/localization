using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.WebApi;
using Owin;


namespace Acr.Localization.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new ConfigurationSettingsReader());
            var container = builder.Build();

            var cfg = new HttpConfiguration
            {
                DependencyResolver = new AutofacWebApiDependencyResolver(container)
            };
            cfg.MapHttpAttributeRoutes();
            cfg.EnsureInitialized();
            app.UseWebApi(cfg);
        }
    }
}
